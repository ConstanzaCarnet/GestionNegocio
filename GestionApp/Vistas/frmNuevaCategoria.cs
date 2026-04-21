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
            string descripcion = txtDescripcion.Text;
            if (descripcion == null) descripcion = "Sin descripcion";
            //instancio categoriadto
            var categoria = new CategoriaDto
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
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
