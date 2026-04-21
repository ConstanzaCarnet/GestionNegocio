using GestionApp.src.Data;
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
    public partial class frmNuevoProducto : Form
    {
        public frmNuevoProducto()
        {
            InitializeComponent();
        }
        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        //cargar categorias en combo
        private void CargarCategorias()
        {
            using var db = new AppDbContext();

            var categorias = db.Categorias
                .Select(c => new
                {
                    c.IdCategoria,
                    c.Nombre
                })
                .ToList();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
        }
        //verifico txts
        public void VerificarTxt()
        {
            if (txtNombre.Text == "" || txtPCompra.Text == "" || txtPVenta.Text == "" || txtStock.Text == "")
            {
                cmdAgregar.Enabled = false;
            }
            else
            {
                cmdAgregar.Enabled = true;
            }
        }
        public void LimpiarTxt()
        {
            txtPVenta.Text = "";
            txtPCompra.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            VerificarTxt();
        }

        private void txtPCompra_TextChanged(object sender, EventArgs e)
        {
            VerificarTxt();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            VerificarTxt();
        }

        private void txtPVenta_TextChanged(object sender, EventArgs e)
        {
            VerificarTxt();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //valido que los valores en los txt estén correctos
                if (!int.TryParse(txtStock.Text, out _))
                {
                    MessageBox.Show("El stock debe ser un número", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStock.Text = "";
                    return;
                }
                //valido que txtPCompra sea decimal
                if (!int.TryParse(txtPCompra.Text, out _))
                {
                    MessageBox.Show("El precio de compra no es válido", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPCompra.Text = "";
                    return;
                }
                if (!int.TryParse(txtPVenta.Text, out _))
                {
                    MessageBox.Show("El precio de lista no es válido", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPVenta.Text = "";
                    return;
                }
                if (cmbCategoria.SelectedValue == "")
                {
                    MessageBox.Show("Debes elegir una categoría", "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var service = new ProductoService();
                var dto = new CrearProductoDto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    PrecioCompra = decimal.Parse(txtPCompra.Text),
                    PrecioVenta = decimal.Parse(txtPVenta.Text),
                    Stock = int.Parse(txtStock.Text),
                    IdCategoria = (int)cmbCategoria.SelectedValue
                };
                service.CrearProducto(dto);
                MessageBox.Show("Producto creado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTxt();
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
