using GestionApp.src.Models;
using GestionApp.src.Services;
using GestionApp.src.Services.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp.Vistas
{
    public partial class frmConfiguraciónEnvíoEmails : FormBase
    {
        //instancio el servicio de configuración
        private readonly ConfiguracionService configuracionService;
        private readonly MensajeriaService mensajeriaService;
        public frmConfiguraciónEnvíoEmails()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdGuardar, IconosUI.Guardar);
            IconosUI.AplicarIconoBoton(cmdProbar, IconosUI.Probar);
            configuracionService = new ConfiguracionService();
            mensajeriaService = new MensajeriaService();
        }
        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            // Validamos el formato del email antes de guardar
            if (!EmailValido(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Creamos un objeto de configuración con los datos ingresados
            var config = new src.Models.ConfiguracionEmail
            {
                EmailEmisor = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            configuracionService.GuardarConfig(config);
            MessageBox.Show("Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidarTxt();
        }
        public void ValidarTxt()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                cmdGuardar.Enabled = false;
                cmdProbar.Enabled = false;
            }
            else
            {
                cmdGuardar.Enabled = true;
                cmdProbar.Enabled = true;
            }
        }

        private void lnkAyuda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAyuda ventana = new frmAyuda("configuracionEmail");
            ventana.ShowDialog();
        }

        private async void cmdProbar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos una config temporal con lo que hay en los TextBox
                var configTemp = new ConfiguracionEmail
                {
                    EmailEmisor = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Host = "smtp.gmail.com",
                    Puerto = 587
                };

                // Llamamos a un método de prueba en el service
                await mensajeriaService.ProbarConexion(configTemp);

                MessageBox.Show("¡Conexión exitosa! El sistema ya puede enviar correos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfiguraciónEnvíoEmails_Load(object sender, EventArgs e)
        {

        }

        //funcion que valide email
        private bool EmailValido(string email)
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
    }
}
