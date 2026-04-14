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
    public partial class frmNuevoCliente : Form
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
        }
        //instancio servicio
        ClienteService servicio = new ClienteService();

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
            //verificamos valores de email
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("Verifica el email!");
                txtEmail.Text = "";
                return;
            }
            //instancio ClienteDto
            CrearClienteDto cliente = new CrearClienteDto();
            //tomo datos del formulario
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;
            //llamo metodo del servicio
            servicio.CrearCliente(cliente);
            MessageBox.Show("Cliente creado con éxito!");
            Limpiar();
        }
    }
}
