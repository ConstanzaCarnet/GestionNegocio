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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionApp
{
    public partial class frmVerClientes : Form
    {
        public frmVerClientes()
        {
            InitializeComponent();
            //seteo la grilla para que no me duplique los datos
            dgvGrilla.AutoGenerateColumns = false;
        }

        ClienteService service = new ClienteService();
        private void cmdTodos_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = service.ObtenerTodos();
        }

        private void cmdDeudores_Click(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = service.ObtenerDeudores();
        }

        private void frmVerClientes_Load(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = service.ObtenerTodos();
        }
    }
}
