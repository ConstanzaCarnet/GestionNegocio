using GestionApp.src.DTOs.Response;
using GestionApp.src.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp
{
    public partial class frmDetalleVenta : FormBase
    {
        private VentaService _ventaService = new VentaService();
        private MensajeriaService _mensajeriaService = new MensajeriaService();
        private VentaListDto _venta;

        public frmDetalleVenta(VentaListDto venta)
        {
            InitializeComponent();
            //icono en el botón de acción
            IconosUI.AplicarIconoBoton(cmdEmail, IconosUI.Email);
            _venta = venta;
            //Cargamos los datos
            lblCliente.Text = venta.Cliente;
            lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy");
            lblTotal.Text = venta.Total.ToString("'$' #,##0.00");

        }
        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            dgvGrilla.AutoGenerateColumns = false;
            dgvGrilla.DataSource = _ventaService.ObtenerDetalleDeVenta(_venta.IdVenta);
        }

        private async void cmdEmail_Click(object sender, EventArgs e)
        {
            // Validar que tenga telefono o email
            bool tieneEmail = !string.IsNullOrWhiteSpace(_venta.Email);
            bool tieneTelefono = !string.IsNullOrWhiteSpace(_venta.Telefono);

            if (!tieneEmail && !tieneTelefono)
            {
                MessageBox.Show("El cliente no posee datos de contacto registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var detalles = (List<DetalleVentaDto>)dgvGrilla.DataSource;
            //Preparar el mensaje
            string mensaje = $"Hola {_venta.Cliente}, te adjuntamos el detalle de tu compra realizada el {_venta.Fecha:dd/MM/yyyy}. Total: ${_venta.Total:N2}.";

            // Ofrecer opciones según disponibilidad
            if (tieneEmail && tieneTelefono)
            {
                var result = MessageBox.Show("¿Desea enviar por WhatsApp? (Presione 'No' para enviar por Email)",
                                           "Seleccionar medio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) EnviarPorWpp(mensaje, detalles);
                else if (result == DialogResult.No) await EnviarPorMail(mensaje);
            }
            else if (tieneTelefono)
            {
                EnviarPorWpp(mensaje, detalles);
            }
            else
            {
                await EnviarPorMail(mensaje);
            }
        }
        //Funciones de mensajeria
        private void EnviarPorWpp(string msg, List<DetalleVentaDto> detalles)
        {
            string ticket = _ventaService.GenerarTicketTexto(_venta, detalles);
            _mensajeriaService.EnviarWhatsApp(_venta.Telefono, msg);
        }
        private async Task EnviarPorMail(string msg)
        {
            // Deshabilitamos el botón y avisamos mientras se envía (la conexión SMTP puede demorar).
            cmdEmail.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                await _mensajeriaService.EnviarEmailHtml(_venta.Email, "Detalle de Compra - GestionApp", msg);
                MessageBox.Show("El email se envió correctamente.", "Email enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo enviar el email: {ex.Message}", "Error al enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                cmdEmail.Enabled = true;
            }
        }



    }

}
