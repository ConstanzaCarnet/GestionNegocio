using GestionApp.src.DTOs.Response;
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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            //evito que se dupliquen columnas
            dgvGrilla.AutoGenerateColumns = false;
        }
        private void frmVentas_Load(object sender, EventArgs e)
        {
            //por defecto al abrir la ventana
            rdbCliente.Checked = true;
            dgvGrilla.AutoGenerateColumns = false;
        }
        //servicios
        private ProductoService _productoService = new ProductoService();
        private VentaService _ventaService = new VentaService();
        private ClienteService _clienteService = new ClienteService();

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            MostrarComb();
            cmbOpciones.DataSource = null;
            cmbOpciones.DataSource = _clienteService.ObtenerTodos();
            cmbOpciones.DisplayMember = "NombreCompleto";
            cmbOpciones.ValueMember = "IdCliente";
        }

        private void rdbMes_CheckedChanged(object sender, EventArgs e)
        {
            // Si elegimos Mes, ocultamos el ComboBox de opciones y mostramos el DateTimePicker
            cmbOpciones.Visible = false;
            dtpPeriodo.Visible = rdbMes.Checked;

            if (rdbMes.Checked)
            {
                dtpPeriodo.Location = cmbOpciones.Location;
            }
        }
        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            MostrarComb();
            cmbOpciones.DataSource = null;
            cmbOpciones.DataSource = _productoService.ObtenerTodos();
            cmbOpciones.DisplayMember = "Nombre";
            cmbOpciones.ValueMember = "IdProducto";
        }
        public void MostrarComb()
        {
            //oculto datetimepciker y muestro el combo
            dtpPeriodo.Visible = false;
            cmbOpciones.Visible = true;
        }

        private void cmdMostrar_Click(object sender, EventArgs e)
        {
            List<VentaListDto> resultado;
            if (rdbMes.Checked)
            {
                //tomo mes y año del picker
                int mes = dtpPeriodo.Value.Month;
                int año = dtpPeriodo.Value.Year;
                resultado = _ventaService.ObtenerVentasFiltrar("Mes", mes, año);
            }
            else
            {
                if (cmbOpciones.SelectedValue == null)
                {
                    MessageBox.Show("No has seleccionado ningun valor para buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //sea clientes o productos tomo el id
                int id = (int)cmbOpciones.SelectedValue;
                string tipo = rdbCliente.Checked ? "Cliente" : "Producto";
                resultado = _ventaService.ObtenerVentasFiltrar(tipo, id);
            }
            //finalmente muestro en grilla
            dgvGrilla.DataSource = null;//limpio grilla
            //valido si encontro algo
            if (resultado == null || !resultado.Any())
            {
                MessageBox.Show("No se encontró ninguna venta", "Sin datos");
                return;
            }
            dgvGrilla.DataSource = resultado;
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGrilla.Columns["cmdVerDetalle"].Index && e.RowIndex >= 0)
            {
                // Obtenemos el objeto VentaListDto de la fila actual
                var ventaSeleccionada = (VentaListDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;

                // Abrimos la ventana de detalle pasando el DTO
                var frmDetalle = new frmDetalleVenta(ventaSeleccionada);
                frmDetalle.ShowDialog();
            }
        }
    }
}
