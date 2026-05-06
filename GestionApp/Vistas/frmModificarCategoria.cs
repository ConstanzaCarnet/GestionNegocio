using GestionApp.src.DTOs.Request;
using GestionApp.src.Models;
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
    public partial class frmModificarCategoria : Form
    {
        private int _idCategoria;
        private CategoríaService _categoriaService = new CategoríaService();
        public frmModificarCategoria(int idCategoria)
        {
            InitializeComponent();
            _idCategoria = idCategoria;
        }

        private void frmModificarCategoria_Load(object sender, EventArgs e)
        {
            //busco la categoria por id
            var categoria = _categoriaService.ObtenerPorId(_idCategoria);
            if (categoria != null)
            {
                txtNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion;
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            //valido que si el nombre no se cambio, se pueda guardar y si el nombre se cambio, se valida que no queden 2 categorias con el mismo nombre
            if (_categoriaService.ExisteNombreDuplicado(txtNombre.Text.Trim(), _idCategoria))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre. Por favor, elija otro nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //creo 
            var dto = new CategoriaDto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text.Trim()
            };
            //actualizo la categoría
            try
            {
                _categoriaService.Actualizar(_idCategoria, dto);
                MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                //recargo el formulario de categorias para que se refleje el cambio
                frmVerCategorías frm = new frmVerCategorías();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                cmdGuardar.Enabled = false;
            }
            else
            {
                cmdGuardar.Enabled = true;
            }
        }
    }
}
