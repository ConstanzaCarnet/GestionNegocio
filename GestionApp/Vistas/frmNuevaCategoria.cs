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

namespace GestionApp.Vistas
{
    public partial class frmNuevaCategoria : Form
    {
        public frmNuevaCategoria()
        {
            InitializeComponent();
        }
        //servicio
        private CategoríaService _categoriaService = new CategoríaService();
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")//la descripcion no es informacion obligatoria
            {
                cmdCrear.Enabled = false;
            }
            else
            {
                cmdCrear.Enabled = true;
            }
        }

        private void cmdCrear_Click(object sender, EventArgs e)
        {
            //realizo validaciones
            string nombre = txtNombre.Text.Trim();
            if (_categoriaService.ExisteNombre(nombre))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //instancio categoriadto
            var categoria = new CategoriaDto
            {
                Nombre = txtNombre.Text,
                Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text
            };
            //llamo la funcion del servicio
            _categoriaService.Crear(categoria);
            MessageBox.Show("Categoría creada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //limpio formulario
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }
    }
}
