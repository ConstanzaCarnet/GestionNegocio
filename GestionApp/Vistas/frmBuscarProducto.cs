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
    public partial class frmBuscarProducto : Form
    {
        public frmBuscarProducto()
        {
            InitializeComponent();
        }
        //inicializo servicio de producto
        private ProductoService _productoServicio = new ProductoService();
        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            dgvGrilla.AutoGenerateColumns = false;
            //utilizamos caracteristicas propias del form
            txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            CargarSugerencias();
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

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarSugerencias();
        }

        //Rellenado de grillas
        private void ActualizarGrilla()
        {
            string busqueda = txtProducto.Text;
            var resultados = _productoServicio.BuscarProducto(busqueda);

            dgvGrilla.DataSource = resultados;
            if (!resultados.Any())
            {
                MessageBox.Show("No se encontró ningun producto con ese nombre", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text)) return;
            ActualizarGrilla();
            txtProducto.Text = "";
        }
    }
}
