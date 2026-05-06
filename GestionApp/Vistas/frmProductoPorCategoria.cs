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
    public partial class frmProductoPorCategoria : Form
    {
        public frmProductoPorCategoria()
        {
            InitializeComponent();
        }
        //instancui servicio
        private ProductoService _productoService = new ProductoService();
        private CategoríaService _categoriaService = new CategoríaService();
        private void frmProductoPorCategoria_Load(object sender, EventArgs e)
        {
            dgvGrilla.AutoGenerateColumns = false;
            CargarComboCategorias();
        }
        private void CargarComboCategorias()
        {
            cbmCategorias.DataSource = _categoriaService.Obtener();
            cbmCategorias.DisplayMember = "Nombre";
            cbmCategorias.ValueMember = "IdCategoria";
            cbmCategorias.SelectedIndex = -1;
        }

        private void cbmCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que SelectedValue sea realmente un número entero
            if (cbmCategorias.SelectedValue != null && cbmCategorias.SelectedValue is int idCate)
            {
                ActualizarGrilla(idCate);
            }
        }
        public void ActualizarGrilla(int idCate)
        {
            var productos = _productoService.BuscarPorCategoria(idCate);
            //limpio grilla
            dgvGrilla.DataSource = null;
            //relleno la grilla con los datos
            dgvGrilla.DataSource = productos;
            //por si no encontro nada ,le aviso al cliente
            if (!productos.Any())
            {
                MessageBox.Show("No se encontraron productos con esa categoría", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
