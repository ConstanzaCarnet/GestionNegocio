using GestionApp.src.DTOs.Response;
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

namespace GestionApp
{
    public partial class frmProductoPorCategoria : FormBase
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
            // 1. Obtenemos la lista desde el servicio
            var listaCategorias = _categoriaService.Obtener().ToList();
            // 2. Creamos el ítem "Ver Todos" con un Id que represente "ninguno" o "todos" (ej: 0 o -1)
            var itemTodos = new Categoria { IdCategoria = 0, Nombre = "Ver todos" };
            // 3. Lo insertamos al principio de la lista (índice 0)
            listaCategorias.Insert(0, itemTodos);
            // 4. Asignamos la lista modificada al ComboBox
            cbmCategorias.DataSource = listaCategorias;
            cbmCategorias.DisplayMember = "Nombre";
            cbmCategorias.ValueMember = "IdCategoria";
            // 5. No muestra nada por defecto
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
            List<ProductoDto> productos;
            if (idCate == 0)
            {
                productos = _productoService.ObtenerTodos();
            }
            else
            {
                productos = _productoService.BuscarPorCategoria(idCate);
            }
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
