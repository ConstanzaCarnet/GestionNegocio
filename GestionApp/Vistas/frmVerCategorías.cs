using GestionApp.src.DTOs.Request;
using GestionApp.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionApp.Vistas
{
    public partial class frmVerCategorías : FormBase
    {
        public frmVerCategorías()
        {
            InitializeComponent();
            dgvGrilla.AutoGenerateColumns = false;
            //iconos en las columnas de acción de la grilla
            IconosUI.AplicarIcono(cmdModificar, IconosUI.Editar, "Modificar");
            IconosUI.AplicarIcono(cmdEliminar, IconosUI.Eliminar, "Eliminar");
            //icono en el botón de acción
            IconosUI.AplicarIconoBoton(cmdCrear, IconosUI.Agregar);

            // Columna para el ID (Oculta)
            dgvGrilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdCategoria",
                Name = "IdCategoria",
                Visible = false
            });
        }
        //servicios
        private CategoríaService _categoriaService = new CategoríaService();
        private void frmVerCategorías_Load(object sender, EventArgs e)
        {
            // Columna para el ID (Oculta)
            dgvGrilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdCategoria",
                Name = "IdCategoria",
                Visible = false
            });
            RefrescarGrilla();
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //validamos que no se seleccione el encabezado
            if (e.RowIndex < 0) return;
            //obtenemos idCategoria
            int id = (int)dgvGrilla.Rows[e.RowIndex].Cells["IdCategoria"].Value;
            string nombre = dgvGrilla.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            //verificamos si se hizo click en el botón eliminar
            if (dgvGrilla.Columns[e.ColumnIndex].Name == "cmdEliminar")
            {
                var confirmacion = MessageBox.Show($"¿Desea eliminar la categoría '{nombre}'?",
                            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        _categoriaService.Eliminar(id);
                        RefrescarGrilla();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            //o si fue el cmdModificar
            else if (dgvGrilla.Columns[e.ColumnIndex].Name == "cmdModificar")
            {
                //abrimos el formulario de modificar
                var frm = new frmModificarCategoria(id);
                frm.ShowDialog();
                RefrescarGrilla();
            }
        }

        //refrescar grilla
        public void RefrescarGrilla()
        {
            dgvGrilla.DataSource = null;
            dgvGrilla.DataSource = _categoriaService.Obtener();
        }
        /////////CREACION DE CATEGORÍA///////////////////////////   
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
            try
            {
                _categoriaService.Crear(categoria);
                MessageBox.Show("Categoría creada con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //limpio formulario
                txtDescripcion.Text = "";
                txtNombre.Text = "";
                //refresco grilla
                RefrescarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo crear", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
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

    }

}
    

