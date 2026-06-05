using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp.Vistas
{
    public partial class frmAyuda : FormBase
    {
        string tipo = "";
        public frmAyuda(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            //cargo la ayuda que corresponda, de esta forma será reutilizable si hace falta
            if (tipo == "configuracionEmail")
            {
                this.Text = "Ayuda para Configuración de Gmail";
                lnkRedirecion.Text = "Ir a Configuración de Gmail";
                ConfigurarAyudaEmail();
            }
        }
        private void ConfigurarAyudaEmail()
        {
            //titulo principal
            lblTitulo.Text = "Configuración de Seguridad de Gmail";
            lblTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            //contenido
            lblAyuda.Text = "Para que la aplicación pueda enviar emails, Google requiere una validación especial.";
            string pasos =
                "1. Active la Verificación en 2 pasos: En su cuenta de Google, vaya a Seguridad y active la protección por SMS o App.\r\n\r\n" +
                "2. Genere la Clave: Busque \"Contraseñas de aplicaciones\". Elija \"Otra\" y escriba \"Aries Business\".\r\n\r\n" +
                "3. Copie el código: Google le dará un código de 16 letras. Cópielo y péguelo en el campo \"Contraseña\" de esta ventana.\r\n\r\n" +
                "Nota: No use su contraseña normal de Gmail, no funcionará por seguridad.";
            lblPasos.Text = pasos;

        }

        private void lnkRedirecion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Abre directamente la sección de seguridad de Google para que el usuario pueda configurar su cuenta
            try
            {
                Process.Start(new ProcessStartInfo("https://myaccount.google.com/apppasswords"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir google, deberá hacerlo manualmente desde su navegador");
            }
        }
    }
}
