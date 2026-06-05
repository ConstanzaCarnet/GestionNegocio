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
        // Geocodifica una dirección: devuelve la primera coincidencia con coordenadas,
        // o null si no se encontró ninguna ubicable en el mapa.
        public static async Task<DireccionSugerida?> GeocodificarAsync(string direccion)
        {
            var lista = await SugerirDireccionesAsync(direccion, 1);
            return lista.FirstOrDefault(d => d.Lat != 0 || d.Lon != 0);
        }
        /// Arma un mapa estático centrado en lat/lon uniendo "tiles" (mosaicos) de
        /// OpenStreetMap y dibuja un marcador rojo en el centro. Devuelve null si no se pudo generar (por ejemplo, sin conexión).
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
        // Conecta un TextBox de dirección con el autocompletado de Georef: mientras el
        // usuario escribe (con una breve pausa), trae sugerencias y se las ofrece.
        // Se usa en frmNuevoCliente y en frmBuscarCliente (al modificar) para no repetir código.
        public static void HabilitarAutocompletadoDireccion(TextBox txt)
        {
            // El autocompletado de WinForms no funciona en TextBox multilínea.
            txt.Multiline = false;
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Un temporizador hace de "debounce": evita llamar a la API en cada tecla.
            var debounce = new System.Windows.Forms.Timer { Interval = 500 };
            txt.TextChanged += (s, e) => { debounce.Stop(); debounce.Start(); };
            debounce.Tick += async (s, e) =>
            {
                debounce.Stop();
                if (!txt.Enabled) return;          // solo sugerimos cuando el campo es editable
                string texto = txt.Text;
                if (texto.Trim().Length < 4) return;

                var sugerencias = await SugerirDireccionesAsync(texto, 5);
                if (sugerencias.Count == 0) return;

                var fuente = new AutoCompleteStringCollection();
                fuente.AddRange(sugerencias.Select(s2 => s2.Nomenclatura).ToArray());
                txt.AutoCompleteCustomSource = fuente;
            };
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
}
