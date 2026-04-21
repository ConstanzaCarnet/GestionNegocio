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
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }
        //instancio servicio
        private ClienteService _clienteService = new ClienteService();
        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            dgvGrilla.AutoGenerateColumns = false;
            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CargarAutocompletado();
        }

        //Autocompletado
        public void CargarAutocompletado()
        {
            var nombres = _clienteService.ObtenerNombresSugeridos();
            if (nombres != null && nombres.Length > 0)
            {
                AutoCompleteStringCollection fuente = new AutoCompleteStringCollection();
                fuente.AddRange(nombres);
                txtCliente.AutoCompleteCustomSource = fuente;
            }
        }
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
           // CargarAutocompletado();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text)) return;
            string buscado = txtCliente.Text;
            var cliente = _clienteService.ObtenerPorNombreCompleto(buscado);
            if (cliente != null)
            {
                // Llenamos los campos del formulario con los datos del DTO
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;

                // Si tienes un label o txt para el saldo:
                lblSaldo.Text = $"Saldo: {cliente.Saldo:C}";
                CargarMovimientos(cliente.IdCliente);
                txtCliente.Text = "";
            }
            else
            {
                MessageBox.Show("No se encontró el cliente seleccionado", "Aviso");
            }
        }

        //grilla
        private void CargarMovimientos(int idCliente)
        {
            //obtenemos movimientos
            var movimientos = _clienteService.ObtenerMoviminetos(idCliente);
            //mostramos
            dgvGrilla.DataSource = null;
            dgvGrilla.DataSource = movimientos;
            //le damos colorsito para mejorar la visibilidad de los datos y facilitar la lectutra
            FormatearGrillaMov();
        }

        //colorsitos! ventas--> rojo, pagos---> verdes
        private void FormatearGrillaMov()
        {
            foreach (DataGridViewRow row in dgvGrilla.Rows)
            {
                if (row.Cells["Tipo"].Value == "Venta")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }


    }

}
