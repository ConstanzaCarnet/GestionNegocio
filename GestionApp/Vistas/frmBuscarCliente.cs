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
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }
        //instancio servicios
        private ClienteService _clienteService = new ClienteService();
        private CuentaCorrienteServices _cuentaCorrienteServices = new CuentaCorrienteServices();
        //instancio variable para que guarde el id del cliente seleccionado y poder usarlo para cargar los movimientos y cargar el pago
        private int idClienteSeleccionado = 0;
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
                //guardamos el ID del cliente seleccionado en la variable global para poder usarlo en otras funciones
                idClienteSeleccionado = cliente.IdCliente; // Guardamos el ID del cliente seleccionado
                // Llenamos los campos del formulario con los datos del DTO
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;

                // Si tienes un label o txt para el saldo:
                lblSaldo.Text = $"Saldo: {cliente.Saldo}";
                CargarMovimientos(cliente.IdCliente);
                txtCliente.Text = "";
                //habilito funciones
                cmdCargarPago.Enabled = true;
                cmdEliminar.Enabled = true;
                cmdModificar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró el cliente seleccionado", "Aviso");
            }
        }

        //grilla
        private void CargarMovimientos(int idCliente)
        {
            //cargamos movimientos
            dgvGrilla.DataSource = null;
            dgvGrilla.DataSource = _clienteService.ObtenerMoviminetos(idCliente); ;
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

        private void cmdCargarPago_Click(object sender, EventArgs e)
        {
            //valido si tiene saldo, si no posee saldo no dejo cargar pago, si posee saldo, abro ventana de cargar pago
            decimal saldo = _cuentaCorrienteServices.ObtenerSaldo(idClienteSeleccionado);
            if (saldo <= 0)
            {
                MessageBox.Show("El cliente no posee saldo pendiente, no se puede cargar un pago");
                return;
            }
            MessageBox.Show("El cliente posee "+saldo+" de saldo pendiente, se abrirá la ventana para cargar el pago");//le aviso cuanto saldo es el pendiente
            frmCargarPago ventana = new frmCargarPago(idClienteSeleccionado);
            ventana.ShowDialog();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            cmdEliminar.Enabled = false;
            cmdGuardar.Enabled = true;
            cmdModificar.Enabled = false;
            cmdBuscar.Enabled = false;
            cmdCargarPago.Enabled = false;
            //habilito las cajas de texto para poder modificar los datos del cliente, bloqueo la grilla para que no se pueda modificar nada ahí
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            dgvGrilla.Enabled = false;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            //bloqueo botones para evitar que se puedan hacer otras acciones mientras se guardan los cambios
            cmdGuardar.Enabled = false;
            cmdEliminar.Enabled = true;
            cmdModificar.Enabled = true;
            cmdBuscar.Enabled = true;
            cmdCargarPago.Enabled = true;
            //deshabilito las cajas de texto para que no se puedan modificar los datos del cliente, habilito la grilla(por interfaz)
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            dgvGrilla.Enabled = true;
            //guardo los cambios
            try
            {
                //creo ActualizarClienteDto con los datos del formulario
                var dto = new ActualizarClienteDto
                {
                    IdCliente = idClienteSeleccionado,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };
                //actualizo el cliente con el servicio
                _clienteService.Actualizar(dto);
                MessageBox.Show("Cliente modificado correctamente");
                //refresco datos
                cmdBuscar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar cliente: {ex.Message}");
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            //le pregunto al usuario si está seguro de eliminar el cliente, si dice que sí, elimino el cliente y refresco la grilla
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _clienteService.Eliminar(idClienteSeleccionado);
                    MessageBox.Show("Cliente eliminado correctamente");
                    //refresco datos
                    cmdBuscar_Click(sender, e);
                    //limpio campos
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    lblSaldo.Text = "Saldo: 0";
                    dgvGrilla.DataSource = null;
                    //deshabilito botones de acciones para evitar errores por falta de cliente seleccionado
                    cmdCargarPago.Enabled = false;
                    cmdEliminar.Enabled = false;
                    cmdModificar.Enabled = false;
                    cmdGuardar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
                }
            }
        }
    }

}
