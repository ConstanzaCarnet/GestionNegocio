using GestionApp.src.DTOs.Request;
using GestionApp.src.Services;
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
    public partial class frmCargarPago : Form
    {
        public frmCargarPago(int idCliente)
        {
            InitializeComponent();
            //valido que el idCliente sea mayor a 0, si es 0 es porque se llama desde el menú, si no es porque se llama desde el formulario de cliente para cargar un pago directo
            if (idCliente > 0)
            {
                cmbCliente.SelectedValue = idCliente;
                cmbCliente.Enabled = false; //deshabilito el combo para que no se pueda cambiar el cliente
            }
        }
        //servicios
        private PagoService pagoService = new PagoService();
        private ClienteService clienteService = new ClienteService();
        private void cmdCargar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !int.TryParse(txtMonto.Text, out _))
            {
                MessageBox.Show("Ingrese un monto válido", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dto = new CrearPagoDto
                {
                    IdCliente = (int)cmbCliente.SelectedValue,
                    Monto = decimal.Parse(txtMonto.Text),
                    MetodoPago = cmbMetodo.Text
                };

                pagoService.RegistrarPago(dto);

                MessageBox.Show("Pago registrado correctamente");
                //limpio formulario
                txtMonto.Clear();
                cmbCliente.SelectedIndex = -1;
                cmbMetodo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCargarPago_Load(object sender, EventArgs e)
        {
            //cargamos combo clientes
            cmbCliente.DataSource = clienteService.ObtenerDeudores(); //en este caso solo cargamos clientes con deuda, por ahora no se puede tener credito a favor en el sistema
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "IdCliente";
            //cargamos combo metodo de pago
            cmbMetodo.DataSource = pagoService.ObtenerMetodosPago();
            cmbMetodo.SelectedIndex = 1;
        }
    }
}
