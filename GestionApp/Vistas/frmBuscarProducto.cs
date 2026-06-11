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
    public partial class frmBuscarProducto : FormBase
    {
        public frmBuscarProducto()
        {
            InitializeComponent();
            //iconos en los botones de acción
            IconosUI.AplicarIconoBoton(cmdBuscar, IconosUI.Buscar);
            IconosUI.AplicarIconoBoton(cmdGuardar, IconosUI.Guardar);
            IconosUI.AplicarIconoBoton(cmdModificar, IconosUI.Editar);
            IconosUI.AplicarIconoBoton(cmdEliminar, IconosUI.Eliminar);
            IconosUI.AplicarIconoBoton(cmdCancelar, IconosUI.Cancelar);
        }
        //inicializo servicio de producto
        private ProductoService _productoServicio = new ProductoService();
        private CategoríaService _categoriaService = new CategoríaService();
        //instalcio una variable para guardar el producto seleccionado
        private int idProductoSeleccionado;
        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            //utilizamos caracteristicas propias del form
            txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            CargarSugerencias();
            //dejo cargada la categoria en el combo
            cmbCategoria.DataSource = _categoriaService.Obtener();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = -1;
        }
        private void CargarSugerencias()
        {
            var nombres = _productoServicio.ObtenerNombresSugeridos();
            if (nombres != null && nombres.Length > 0)
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                source.AddRange(nombres);
                txtProducto.AutoCompleteCustomSource = source;
            }
        }
        private void SeleccionarCategoria(string categoria)
        {
            //busco el id de la categoria por su nombre
            var cat = _categoriaService.Obtener().FirstOrDefault(c => c.Nombre == categoria);
            //dejo seleccionado el combo por id
            if (cat.Nombre == "Sin categoría")
            {
                cmbCategoria.SelectedIndex = -1;
                return;
            }
            cmbCategoria.SelectedValue = cat.IdCategoria;
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarSugerencias();
        }

        //Rellenado de grillas
        private void BuscarProducto()
        {
            string busqueda = txtProducto.Text;
            var resultado = _productoServicio.BuscarProducto(busqueda).FirstOrDefault();

            if (resultado == null)
            {
                MessageBox.Show("No se encontró ningun producto con ese nombre", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //dejo establecido el producto
            idProductoSeleccionado = resultado.IdProducto;
            //actualizo los datos de los txt
            MostrarDatos(resultado.IdProducto);
        }
        //actualizo por id los txts
        private void MostrarDatos(int idProducto)
        {
            var resultado = _productoServicio.ObtenerPorId(idProducto);
            if (resultado == null)
            {
                MessageBox.Show("No se encontró el producto", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //actualizo los datos de los txt
            txtNombre.Text = resultado.Nombre;
            txtPCompra.Text = resultado.PrecioCompra.Value.ToString("0.00");
            txtPVenta.Text = resultado.PrecioVenta.ToString("0.00");
            txtStock.Text = resultado.Stock.ToString();
            txtDescripcion.Text = resultado.Descripcion;
            SeleccionarCategoria(resultado.Categoria);
            //habilito botones
            cmdModificar.Enabled = true;
            cmdEliminar.Enabled = true;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text)) return;
            BuscarProducto();
            txtProducto.Text = "";
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            cmdEliminar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdBuscar.Enabled = false;
            cmdGuardar.Enabled = true;
            cmdCancelar.Visible = true;
            cmdCancelar.Enabled = true;
            //habilito txts
            habilitarControles(true);
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            //valido los datos
            if (txtNombre.Text == "" || txtPCompra.Text == "" || txtPVenta.Text == "" || txtStock.Text == "" || cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //si hay algun valor numerico que sea string le muestro error
            if (!decimal.TryParse(txtPCompra.Text, out _))
            {
                MessageBox.Show("El precio de compra no es válido", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPCompra.Text = "";
                return;
            }
            if (!decimal.TryParse(txtPVenta.Text, out _))
            {
                MessageBox.Show("El precio de venta no es válido", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPVenta.Text = "";
                return;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("El stock debe ser un número", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Text = "";
                return;
            }
            //creo dto para actualizar producto
            var dto = new ActualizarProductoDto
            {
                IdProducto = idProductoSeleccionado,
                Nombre = txtNombre.Text,
                Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? "Sin descripción" : txtDescripcion.Text,
                PrecioCompra = decimal.Parse(txtPCompra.Text),
                PrecioVenta = decimal.Parse(txtPVenta.Text),
                Stock = int.Parse(txtStock.Text),
                IdCategoria = (int)cmbCategoria.SelectedValue
            };
            try
            {
                _productoServicio.Actualizar(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //actualizo datos
            MostrarDatos(idProductoSeleccionado);
            //deshabilito txts
            habilitarControles(false);
            //habilito botones
            cmdModificar.Enabled = true;
            cmdEliminar.Enabled = true;
            cmdBuscar.Enabled = true;
            cmdGuardar.Enabled = false;
            //saco el boton cancelar
            cmdCancelar.Enabled = false;
            cmdCancelar.Visible = false;
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            //confirmo eliminacion
            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _productoServicio.Eliminar(idProductoSeleccionado);
                    MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //limpio txts
                    limpiarControles();
                    //deshabilito botones
                    cmdModificar.Enabled = false;
                    cmdEliminar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            //si el usuario no quiere modificar nada y cancela, vuelvo a mostrar los datos del producto seleccionado
            MostrarDatos(idProductoSeleccionado);
            //controles
            habilitarControles(false);
            //habilito botones
            cmdCancelar.Visible = false;
            cmdCancelar.Enabled = false;
            cmdGuardar.Enabled = false;
            cmdModificar.Enabled = true;
            cmdEliminar.Enabled = true;
            cmdBuscar.Enabled = true;
        }

        public void habilitarControles(bool estado)
        {
            txtNombre.Enabled = estado;
            txtPCompra.Enabled = estado;
            txtPVenta.Enabled = estado;
            txtStock.Enabled = estado;
            cmbCategoria.Enabled = estado;
            txtDescripcion.Enabled = estado;
        }
        public void limpiarControles()
        {
            txtNombre.Text = "";
            txtPCompra.Text = "";
            txtPVenta.Text = "";
            txtStock.Text = "";
            txtDescripcion.Text = "";
            cmbCategoria.SelectedIndex = -1;
        }
    }
}
