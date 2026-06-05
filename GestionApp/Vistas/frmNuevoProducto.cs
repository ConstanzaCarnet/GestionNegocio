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
    public partial class frmNuevoProducto : FormBase
    {
        public frmNuevoProducto()
        {
            InitializeComponent();
            //icono en el botón de acción
            IconosUI.AplicarIconoBoton(cmdAgregar, IconosUI.Agregar);
        }
        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            dgvGrilla.AutoGenerateColumns = false;
            MostrarProductos();
        }
        //service
        private ProductoService _productoService = new ProductoService();
        private CategoríaService _categoriaService = new CategoríaService();
        //cargar categorias en combo
        private void MostrarProductos()
        {
            var data = _productoService.ObtenerTodos();
            dgvGrilla.DataSource = data;
        }
        private void CargarCategorias()
        {

            cmbCategoria.DataSource = _categoriaService.Obtener();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = -1;
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
                if (!int.TryParse(txtPVenta.Text, out _) || decimal.Parse(txtPVenta.Text) <= decimal.Parse(txtPCompra.Text))//reviso que el precio de venta sea decimal y mayor al precio de compra
                {
                    MessageBox.Show("El precio de lista no es válido", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPVenta.Text = "";
                    return;
                }
                //valido que se seleccione una categoría
                if (cmbCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debes elegir una categoría", "Dato incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_productoService.ExisteProducto(txtNombre.Text))//valido que el producto nuevo no exista ya en la base de datos
                {
                    MessageBox.Show("El producto ya existe", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Text = "";
                    return;
                }
                var dto = new CrearProductoDto
                {
                    Nombre = txtNombre.Text,
                    //si descripcion es vacío le doy valor de "Sin descripcion"
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                    PrecioCompra = decimal.Parse(txtPCompra.Text),
                    PrecioVenta = decimal.Parse(txtPVenta.Text),
                    Stock = int.Parse(txtStock.Text),
                    IdCategoria = (int)cmbCategoria.SelectedValue
                };
                _productoService.CrearProducto(dto);
                MessageBox.Show("Producto creado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTxt();
                cmbCategoria.SelectedIndex = -1;
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
