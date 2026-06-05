using GestionApp.Vistas;

namespace GestionApp
{
    public partial class frmHome : FormBase
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoProducto vetana = new frmNuevoProducto();
            vetana.ShowDialog();
        }

        private void buscarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarProducto ventana = new frmBuscarProducto();
            ventana.ShowDialog();
        }

        private void porCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoPorCategoria ventana = new frmProductoPorCategoria();
            ventana.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoCliente ventana = new frmNuevoCliente();
            ventana.ShowDialog();
        }

        private void filtrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarCliente ventana = new frmBuscarCliente();
            ventana.ShowDialog();
        }

        private void cargarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargarPago ventanas = new frmCargarPago(0);
            ventanas.ShowDialog();
        }

        private void cargarNuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaVenta ventana = new frmNuevaVenta();
            ventana.ShowDialog();
        }

        private void verTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas ventana = new frmVentas();
            ventana.Show();
        }
        private void envíoDeEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguraciónEnvíoEmails ventana = new frmConfiguraciónEnvíoEmails();
            ventana.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe ventana = new frmAcercaDe();
            ventana.ShowDialog();
        }

        private void catálogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogos ventana = new frmCatalogos();
            ventana.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerCategorías ventana = new frmVerCategorías();
            ventana.ShowDialog();
        }

        private void balancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBalances ventana = new frmBalances();
            ventana.ShowDialog();
        }
    }
}
