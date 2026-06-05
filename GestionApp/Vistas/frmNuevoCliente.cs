using GestionApp.src.DTOs.Request;
using GestionApp.src.DTOs.Response;
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
    public partial class frmNuevoCliente : FormBase
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
            dgvGrilla.AutoGenerateColumns = false;
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdAgregar, IconosUI.Agregar);
            IconosUI.AplicarIconoBoton(cmdTodos, IconosUI.Lista);
            IconosUI.AplicarIconoBoton(cmdDeudores, IconosUI.Personas);
            //autocompletado de direcciones con la API Georef (gratuita, sin key)
            ExternalServices.HabilitarAutocompletadoDireccion(txtDireccion);
        }
        //instancio servicio
        ClienteService servicio = new ClienteService();
        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = servicio.ObtenerTodos();
        }

        //verifico datos de txt 
        public void txtVerificar()
        {
            if (txtApellido.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtTelefono.Text == "")
            {
                cmdAgregar.Enabled = false;
            }
            else
            {
                cmdAgregar.Enabled = true;
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }
        public bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtVerificar();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtVerificar();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtVerificar();
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            txtVerificar();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            var direccion = txtDireccion.Text;
            //verificamos valores de email, ya sea que es correcto o que existe ya en la base de datos
            if (!ValidarEmail(txtEmail.Text) || servicio.EmailExiste(txtEmail.Text))
            {
                MessageBox.Show("Verifica el email!");
                txtEmail.Text = "";
                return;
            }
            if (string.IsNullOrWhiteSpace(direccion)) direccion = "Sin dirección registrada";//le doy un valor por defecto en caso de que no se cargue direccion
            //valido que el nombre no tenga numeros, ni esté con espacios, ni que exista
            if (txtNombre.Text.Any(char.IsDigit) || string.IsNullOrWhiteSpace(txtNombre.Text) || servicio.ObtenerPorNombreCompleto(txtNombre.Text + " " + txtApellido.Text) != null)
            {
                MessageBox.Show("Verifica el nombre!");
                txtNombre.Text = "";
                return;
            }

            //instancio ClienteDto
            CrearClienteDto cliente = new CrearClienteDto();
            //tomo datos del formulario
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = direccion;
            //llamo metodo del servicio
            servicio.CrearCliente(cliente);
            MessageBox.Show("Cliente creado con éxito!");
            Limpiar();
        }

        private void cmdTodos_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = servicio.ObtenerTodos();
        }

        private void cmdDeudores_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = servicio.ObtenerDeudores();
        }
    }
}
