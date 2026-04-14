namespace GestionApp
{
    public partial class frmHome : Form
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

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerProductos ventana = new frmVerProductos();
            ventana.ShowDialog();
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

        private void comprasDeUnClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerClientes ventanas = new frmVerClientes();
            ventanas.ShowDialog();
        }

        private void filtrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarCliente ventana = new frmBuscarCliente();
            ventana.ShowDialog();
        }

        private void cargarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargarPago ventanas = new frmCargarPago();
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
        }
    }
}
