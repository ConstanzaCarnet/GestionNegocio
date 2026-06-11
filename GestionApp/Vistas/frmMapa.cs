using System;
using System.Drawing;
using System.Windows.Forms;
using GestionApp.src.Services;

namespace GestionApp
{
    /// <summary>
    /// Ventana flotante que muestra en un mapa la ubicación de una dirección ya
    /// geocodificada (con la API Georef). El mapa se arma con tiles de OpenStreetMap.
    /// Es un formulario "solo código" (no tiene diseñador) para mantenerlo simple.
    /// </summary>
    public class frmMapa : FormBase
    {
        private readonly DireccionSugerida _direccion;
        private readonly PictureBox _picMapa;

        public frmMapa(DireccionSugerida direccion)
        {
            _direccion = direccion;

            // Ventana fija y centrada respecto de la ventana que la abre.
            Text = "Ubicación del cliente";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(520, 460);

            // Dirección normalizada arriba.
            var lblDireccion = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(500, 28),
                Text = direccion.Nomenclatura,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
            };

            // El mapa en sí.
            _picMapa = new PictureBox
            {
                Location = new Point(10, 44),
                Size = new Size(500, 360),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Gainsboro
            };

            // Botón para abrirlo en Google Maps (en grande, en el navegador).
            var cmdGoogle = new Button
            {
                Location = new Point(10, 414),
                Size = new Size(500, 34),
                Text = "Ver en Google Maps"
            };
            IconosUI.AplicarIconoBoton(cmdGoogle, IconosUI.Ver);
            cmdGoogle.Click += (s, e) => ExternalServices.AbrirEnGoogleMaps(_direccion.Lat, _direccion.Lon);

            Controls.Add(lblDireccion);
            Controls.Add(_picMapa);
            Controls.Add(cmdGoogle);

            // El mapa se descarga al mostrarse la ventana (sin congelar la interfaz).
            Load += frmMapa_Load;
        }

        private async void frmMapa_Load(object sender, EventArgs e)
        {
            var img = await ExternalServices.ObtenerMapaAsync(
                _direccion.Lat, _direccion.Lon, _picMapa.Width, _picMapa.Height, 15);

            if (img != null)
                _picMapa.Image = img;
        }
    }
}
