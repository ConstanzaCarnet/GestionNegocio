using GestionApp.src.Services;
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
    public partial class frmCatalogos : FormBase
    {
        public frmCatalogos()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdSeleccionarTodos, IconosUI.SeleccionarTodo);
            IconosUI.AplicarIconoBoton(cmdEnviar, IconosUI.Enviar);
            dgvGrilla.AutoGenerateColumns = false;
            dgvGrilla.ReadOnly = false;
            dgvGrilla.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvGrilla.AllowUserToAddRows = false;
        }
        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            CargarClientes();          
        }
        ClienteService clienteService = new ClienteService();
        private string rutaCatalogo;
        public void CargarClientes()
        {
            var clientes = clienteService.ObtenerTodos();
            dgvGrilla.DataSource = clientes;
            dgvGrilla.Columns["Seleccionado"].ReadOnly = false;
            //dgvGrilla.Columns["IdCliente"].Visible = false;
        }

        private void amdExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos PDF|*.pdf|Imágenes|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaCatalogo = ofd.FileName;
                    txtCatalogo.Text = System.IO.Path.GetFileName(rutaCatalogo);
                }
            }
        }

        private void cmdEnviar_Click(object sender, EventArgs e)
        {
            // Aseguramos que el último checkbox tildado quede confirmado en la grilla
            dgvGrilla.EndEdit();

            if (string.IsNullOrEmpty(rutaCatalogo) || !System.IO.File.Exists(rutaCatalogo))
            {
                MessageBox.Show("Debe seleccionar un catálogo (PDF o imagen) con el botón EXAMINAR.");
                return;
            }

            // Reunimos los clientes seleccionados que tengan teléfono cargado
            var destinatarios = new List<string>();
            int sinTelefono = 0;

            foreach (DataGridViewRow row in dgvGrilla.Rows)
            {
                bool seleccionado =
                    row.Cells["Seleccionado"].Value != null &&
                    Convert.ToBoolean(row.Cells["Seleccionado"].Value);

                if (!seleccionado)
                    continue;

                string telefono = row.Cells["Telefono"].Value?.ToString();
                telefono = LimpiarTelefono(telefono);

                if (string.IsNullOrEmpty(telefono))
                {
                    sinTelefono++;
                    continue;
                }

                destinatarios.Add(telefono);
            }

            if (destinatarios.Count == 0)
            {
                MessageBox.Show(
                    sinTelefono > 0
                        ? "Los clientes seleccionados no tienen un teléfono válido cargado."
                        : "Debe seleccionar al menos un cliente.");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"Se abrirán {destinatarios.Count} chat(s) de WhatsApp.\n\n" +
                "En cada chat presione Ctrl+V para pegar el catálogo y luego Enter.\n\n" +
                "Requiere tener WhatsApp Desktop instalado.\n\n¿Desea continuar?",
                "Confirmar envío",
                MessageBoxButtons.YesNo
            );

            if (r == DialogResult.No)
                return;

            // Copiamos el ARCHIVO (no la ruta) al portapapeles para poder pegarlo en el chat
            var archivos = new System.Collections.Specialized.StringCollection();
            archivos.Add(rutaCatalogo);
            Clipboard.SetFileDropList(archivos);

            string mensaje =
                "¡Hola! 😊 Te compartimos nuestro nuevo catálogo de productos.";

            foreach (string telefono in destinatarios)
            {
                string url =
                    $"https://wa.me/{telefono}?text={Uri.EscapeDataString(mensaje)}";

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });

                System.Threading.Thread.Sleep(1500);
            }

            string aviso = $"Se abrieron {destinatarios.Count} chat(s).\n" +
                "El catálogo quedó copiado: en cada chat presione Ctrl+V y luego Enter.";
            if (sinTelefono > 0)
                aviso += $"\n\nSe omitieron {sinTelefono} cliente(s) sin teléfono válido.";

            MessageBox.Show(aviso);
        }

        // Función auxiliar para formatear el número de teléfono
        private string LimpiarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return string.Empty;

            // Elimina caracteres no numéricos
            string soloNumeros = System.Text.RegularExpressions.Regex.Replace(telefono, @"[^\d]", "");

            if (soloNumeros.Length == 0)
                return string.Empty;

            // WhatsApp requiere el código de país (54)
            // y para celulares el '9' antes del código de área (ej: 549351XXXXXXX)
            if (!soloNumeros.StartsWith("54"))
            {
                // lógica según cómo guardes los teléfonos en tu base de datos SQLite
                soloNumeros = "54" + soloNumeros;
            }

            return soloNumeros;
        }

        private void cmdSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvGrilla.Rows)
            {
                fila.Cells["Seleccionado"].Value = true;
            }
        }

    }

}
