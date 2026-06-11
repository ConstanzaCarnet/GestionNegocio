using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp.src.Services
{
    //sacado de: https://datos.gob.ar/apis
    public class DireccionSugerida
    {
        public string Nomenclatura { get; set; } = "";
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    // Servicios que consumen APIs externas gratuitas y SIN clave (API key---> evito tener info que es sensible o debe modificarse cada tanto):
    // * Georef (apis.datos.gob.ar): normaliza y sugiere direcciones de Argentina.
    // * OpenStreetMap (tile.openstreetmap.org): arma un mapa estático.
    // Hago un simple GET vía HttpClient; no requiere instalar paquetes, solo tener las url
    public static class ExternalServices
    {
        // Un único HttpClient reutilizable (buena práctica para no agotar conexiones).
        // El User-Agent es requerido por la política de uso de OpenStreetMap.
        private static readonly HttpClient _http = CrearCliente();

        private static HttpClient CrearCliente()
        {
            var cliente = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
            cliente.DefaultRequestHeaders.UserAgent.ParseAdd("GestionApp/1.0 (aplicacion educativa de gestion)");
            return cliente;
        }
        // Devuelve sugerencias de direcciones normalizadas para el texto ingresado.Ante un error de red o respuesta inesperada devuelve una lista vacía
        // (nunca lanza excepción, para no interrumpir la carga del cliente).
        public static async Task<List<DireccionSugerida>> SugerirDireccionesAsync(string texto, int max = 5)
        {
            var resultado = new List<DireccionSugerida>();
            if (string.IsNullOrWhiteSpace(texto) || texto.Trim().Length < 3)
                return resultado;

            try
            {
                var url = $"https://apis.datos.gob.ar/georef/api/direcciones?direccion={Uri.EscapeDataString(texto)}&max={max}";
                using var stream = await _http.GetStreamAsync(url);
                using var doc = await JsonDocument.ParseAsync(stream);

                foreach (var dir in doc.RootElement.GetProperty("direcciones").EnumerateArray())
                {
                    var item = new DireccionSugerida
                    {
                        Nomenclatura = dir.GetProperty("nomenclatura").GetString() ?? ""
                    };

                    // La ubicación puede venir nula si la API no pudo encontrar la dirección
                    if (dir.TryGetProperty("ubicacion", out var ubic) &&
                        ubic.ValueKind == JsonValueKind.Object &&
                        ubic.TryGetProperty("lat", out var latEl) && latEl.ValueKind == JsonValueKind.Number)
                    {
                        item.Lat = latEl.GetDouble();
                        item.Lon = ubic.GetProperty("lon").GetDouble();
                    }

                    resultado.Add(item);
                }
            }
            catch
            {
                // Sin conexión o respuesta inesperada: devolvemos lo que haya (posiblemente vacío).
            }

            return resultado;
        }
        // Geocodifica una dirección: devuelve la primera coincidencia con coordenadas,o null si no se encontró ninguna ubicable en el mapa.
        public static async Task<DireccionSugerida?> GeocodificarAsync(string direccion)
        {
            var lista = await SugerirDireccionesAsync(direccion, 1);
            return lista.FirstOrDefault(d => d.Lat != 0 || d.Lon != 0);
        }
        // Arma un mapa estático centrado en lat/lon uniendo "tiles" (mosaicos) de OpenStreetMap y dibuja un marcador rojo en el centro. Devuelve null si no se pudo generar (por ejemplo, sin conexión).
        public static async Task<Image?> ObtenerMapaAsync(double lat, double lon, int ancho, int alto, int zoom = 15)
        {
            try
            {
                // Conversión de lat/lon a coordenadas de mosaico (proyección Web Mercator).
                double n = Math.Pow(2, zoom);
                double latRad = lat * Math.PI / 180.0;
                double xMosaico = (lon + 180.0) / 360.0 * n;
                double yMosaico = (1 - Math.Log(Math.Tan(latRad) + 1 / Math.Cos(latRad)) / Math.PI) / 2 * n;

                // Píxel (en coordenadas del mundo) del centro y de la esquina sup-izquierda del recorte.
                double centroX = xMosaico * 256;
                double centroY = yMosaico * 256;
                double izqX = centroX - ancho / 2.0;
                double supY = centroY - alto / 2.0;

                var bmp = new Bitmap(ancho, alto);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Gainsboro);

                    int maxMosaico = (int)n - 1;
                    int tx0 = (int)Math.Floor(izqX / 256), ty0 = (int)Math.Floor(supY / 256);
                    int tx1 = (int)Math.Floor((izqX + ancho) / 256), ty1 = (int)Math.Floor((supY + alto) / 256);

                    for (int tx = tx0; tx <= tx1; tx++)
                    {
                        for (int ty = ty0; ty <= ty1; ty++)
                        {
                            if (tx < 0 || ty < 0 || tx > maxMosaico || ty > maxMosaico) continue;

                            var url = $"https://tile.openstreetmap.org/{zoom}/{tx}/{ty}.png";
                            try
                            {
                                var bytes = await _http.GetByteArrayAsync(url);
                                using var ms = new MemoryStream(bytes);
                                using var mosaico = Image.FromStream(ms);
                                g.DrawImage(mosaico, (int)(tx * 256 - izqX), (int)(ty * 256 - supY));
                            }
                            catch
                            {
                                // Si un mosaico falla, se omite y el resto del mapa igual se dibuja.
                            }
                        }
                    }

                    // Marcador en el centro (la posición buscada).
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    float cx = ancho / 2f, cy = alto / 2f;
                    g.FillEllipse(Brushes.Red, cx - 6, cy - 6, 12, 12);
                    using var pen = new Pen(Color.White, 2);
                    g.DrawEllipse(pen, cx - 6, cy - 6, 12, 12);
                }

                return bmp;
            }
            catch
            {
                return null;
            }
        }
        // Conecta un TextBox de dirección con el autocompletado de Georef.
        // Se apoya en AutocompletadorDireccion (un desplegable propio), porque el
        // AutoComplete nativo de WinForms coincide por prefijo y no sirve con las
        // direcciones ya normalizadas que devuelve Georef.
        // Se usa en frmNuevoCliente y en frmBuscarCliente (al modificar).
        public static void HabilitarAutocompletadoDireccion(TextBox txt)
        {
            // La instancia se mantiene viva a través de los eventos del TextBox.
            new AutocompletadorDireccion(txt);
        }

        // Abre la ubicación en Google Maps usando el navegador por defecto.
        public static void AbrirEnGoogleMaps(double lat, double lon)
        {
            var latStr = lat.ToString(CultureInfo.InvariantCulture);
            var lonStr = lon.ToString(CultureInfo.InvariantCulture);
            var url = $"https://www.google.com/maps?q={latStr},{lonStr}";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }


    /* Muestra, debajo de un TextBox de dirección, un desplegable propio (ListBox) con las sugerencias de Georef. Se usa un ListBox en lugar del AutoComplete
     nativo porque éste sólo coincide por prefijo: el usuario escribe "pellegrini" y Georef devuelve "AV PELLEGRINI ...", que no empieza con lo tipeado.
    */
    public class AutocompletadorDireccion
    {
        private readonly TextBox _txt;
        private readonly ListBox _lista;
        private readonly System.Windows.Forms.Timer _debounce;
        private bool _suprimir;   // evita re-buscar cuando completamos el texto nosotros
        //se puede ver el json:https://apis.datos.gob.ar/georef/api/direcciones?direccion=pellegrini&max=5 para entender mejor el funcionamiento de la API de georef y como se relaciona con este autocompletador.
        public AutocompletadorDireccion(TextBox txt)
        {
            _txt = txt;
            _txt.Multiline = false; // la dirección va en una sola línea
            // El ListBox se crea pero no se agrega aún al formulario, para no interferir con el diseño del GroupBox. Se muestra sólo cuando hay sugerencias.
            _lista = new ListBox { Visible = false, IntegralHeight = false, Height = 120 };
            // El Timer se usa para "debounce": espera a que el usuario deje de escribir por un momento antes de buscar, evitando hacer una consulta por cada letra tipeada.
            _debounce = new System.Windows.Forms.Timer { Interval = 450 };

            // Mientras se escribe (con una breve pausa) buscamos sugerencias.
            // lo que dice aquí es que cada vez que el texto cambia, se reinicia el timer de debounce. Si el usuario sigue escribiendo, el timer nunca llega a su intervalo y no se hace la búsqueda. Solo cuando el usuario deja de escribir por 450 ms, el timer se dispara
            _txt.TextChanged += (s, e) => { if (!_suprimir) { _debounce.Stop(); _debounce.Start(); } };
            _debounce.Tick += async (s, e) => await BuscarAsync();

            // Selección con teclado (flecha abajo / Enter / Escape) o con el mouse.
            _txt.KeyDown += Txt_KeyDown;
            _txt.Leave += (s, e) => { if (!_lista.Focused) _lista.Visible = false; };
            _lista.Click += (s, e) => Elegir();
            _lista.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Elegir(); };
        }

        private async Task BuscarAsync()
        {
            _debounce.Stop();
            if (!_txt.Enabled) return;                 // sólo cuando el campo es editable
            string texto = _txt.Text;
            if (texto.Trim().Length < 4) { _lista.Visible = false; return; }

            var sugerencias = await ExternalServices.SugerirDireccionesAsync(texto, 6);
            if (sugerencias.Count == 0) { _lista.Visible = false; return; }

            _lista.Items.Clear();
            foreach (var sug in sugerencias)
                _lista.Items.Add(sug.Nomenclatura);

            MostrarDesplegable();
        }

        private void MostrarDesplegable()
        {
            var form = _txt.FindForm();
            if (form == null || _txt.Parent == null) return;

            // El ListBox se agrega al formulario (no al GroupBox) para que no quede recortado.
            if (_lista.Parent == null)
                form.Controls.Add(_lista);

            // Lo ubicamos justo debajo del TextBox, traduciendo coordenadas.
            var enPantalla = _txt.Parent.PointToScreen(new Point(_txt.Left, _txt.Bottom));
            _lista.Location = form.PointToClient(enPantalla);
            _lista.Width = _txt.Width;
            _lista.Visible = true;
            _lista.BringToFront();
        }

        private void Elegir()
        {
            var elegido = _lista.SelectedItem?.ToString();
            if (elegido == null) return;

            _suprimir = true;
            _txt.Text = elegido;
            _suprimir = false;

            _lista.Visible = false;
            _txt.Focus();
            _txt.SelectionStart = _txt.Text.Length;
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_lista.Visible) return;

            if (e.KeyCode == Keys.Down && _lista.Items.Count > 0)
            {
                _lista.Focus();
                _lista.SelectedIndex = 0;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _lista.Visible = false;
                e.Handled = true;
            }
        }
    }
}
