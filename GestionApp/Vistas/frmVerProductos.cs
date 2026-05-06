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
    public partial class frmVerProductos : Form
    {
        public frmVerProductos()
        {
            InitializeComponent();
        }

        ProductoService service = new ProductoService();
        private void frmVerProductos_Load(object sender, EventArgs e)
        {
            var data = service.ObtenerTodos();
            dgvGrilla.AutoGenerateColumns = false;
            dgvGrilla.DataSource = data;
        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }
    }
}
