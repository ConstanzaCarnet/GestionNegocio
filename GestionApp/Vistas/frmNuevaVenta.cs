using GestionApp.src.Data;
using GestionApp.src.DTOs.Request;
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
    public partial class frmNuevaVenta : Form
    {
        //lista de items
        private List<ItemVentaDto> _items = new();
        //cliente
        private int idCliente = 0;
        //servicios
        private ProductoService _productoService = new ProductoService();
        private VentaService _ventaService = new VentaService();
        private ClienteService _clienteService = new ClienteService();

        public frmNuevaVenta()
        {
            InitializeComponent();
        }
        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            dgvGrilla.AutoGenerateColumns = false;
            //cargo el combo clientes
            var clientes = _clienteService.ObtenerTodos();
            cbmClientes.DataSource = clientes;
            cbmClientes.DisplayMember = "NombreCompleto";
            cbmClientes.ValueMember = "IdCliente";

            //cargo el combo productos al abrir la ventana
            var productos = _productoService.ObtenerTodos();
            cmbProductos.DataSource = productos;
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";
        }
        //determino IdCliente y muestro cliente en la interfaz
        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (cbmClientes.SelectedValue != null)
            {
                //tomo el IdCliente
                idCliente = (int)cbmClientes.SelectedValue;
                //blockeo los botones
                lblCliente.Text = cbmClientes.Text;
                cmdSeleccionar.Enabled = false;
                cbmClientes.Enabled = false;
                cmdAgregar.Enabled = true;
            }
        }
        //cambio IdCliente
        private void cmdCambiarCliente_Click(object sender, EventArgs e)
        {
            cambiarCliente();
        }
        public void cambiarCliente()
        {
            cmdSeleccionar.Enabled = true;
            cbmClientes.Enabled = true;
            lblCliente.Text = "";
            cmdAgregar.Enabled = false;
        }
        //Agregar producto a items
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            //selecciono elproducto seleccionado
            var producto = (ProductoDto)cmbProductos.SelectedItem;
            int cantidad = Convert.ToInt32(cmbCantidad.Text);
            //verifico cantidad(en caso de que no haya stock)
            if (cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }
            //si ya está ingresado en la lista de items
            var existente = _items.FirstOrDefault(x => x.IdProducto == producto.IdProducto);
            //reviso que no supere el stock
            if (existente != null)
            {
                if ((existente.Cantidad + cantidad) > producto.Stock)
                {
                    MessageBox.Show("No tienes esa cantidad del producto disponible!", "Que lástima!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //si no lo supera, sumo
                existente.Cantidad += cantidad;
            }
            else
            {
                _items.Add(new ItemVentaDto
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    PrecioUnitario = producto.PrecioVenta,
                    Cantidad = cantidad
                });
            }
            ActualizarInterfaz();
        }
        //Guardamos la venta
        private void cmdContinuar_Click(object sender, EventArgs e)
        {
            if (idCliente == null || idCliente == 0)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            if (!_items.Any())
            {
                MessageBox.Show("Debe agregar productos");
                return;
            }

            var ventaDto = new CrearVentaDto
            {
                IdCliente = idCliente,
                Items = _items.Select(x => new CrearDetalleDto
                {
                    IdProducto = x.IdProducto,
                    Cantidad = x.Cantidad
                }).ToList()
            };

            var service = new VentaService();
            service.CrearVenta(ventaDto);

            MessageBox.Show("Venta creada correctamente");
            //limpio lista items
            _items.Clear();
            //limpio grilla
            dgvGrilla.DataSource = null;
            //habilito para elegir otro cliente
            cambiarCliente();
            lblTotal.Text = "";
        }

        //funciones de la grilla
        private void RefrescarGrilla()
        {
            dgvGrilla.DataSource = null;
            dgvGrilla.DataSource = _items;
        }
        private void ActualizarTotal()
        {
            var total = _items.Sum(x => x.Subtotal);
            lblTotal.Text = total.ToString("0.00");
        }


        //combo box de productos y combo box del stock
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //obtenemos el producto
            var productoSeleccionado = cmbProductos.SelectedItem as ProductoDto;
            //Por las dudas, validamos
            if (productoSeleccionado == null) return;

            //tomo el stock
            int stockDisponible = productoSeleccionado.Stock;

            //Creamos la lista de números del 1 al stockDisponible
            if (stockDisponible > 0)
            {
                // Enumerable.Range(inicio, conteo) Metodo propio que nos da .Net
                cmbCantidad.DataSource = Enumerable.Range(1, stockDisponible).ToList();
            }
            else
            {
                cmbCantidad.DataSource = null;
                cmbCantidad.Items.Clear();
                cmbCantidad.Items.Add("Sin stock");
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            //cancelo compra y cierro ventana
            _items.Clear();
            Close();
        }

        //Logica de la grilla
        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtenemos el item una sola vez
            var item = (ItemVentaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            var nombreColumna = dgvGrilla.Columns[e.ColumnIndex].Name;

            switch (nombreColumna)
            {
                case "cmdQuitar":
                    RemoverItem(item);
                    break;

                case "cmdAumentar":
                    ModificarCantidad(item, 1);
                    break;

                case "cmdDisminuir":
                    ModificarCantidad(item, -1);
                    break;
            }
        }

        private void ModificarCantidad(ItemVentaDto item, int cambio)
        {
            int nuevaCantidad = item.Cantidad + cambio;
            var producto = _productoService.ObtenerPorId(item.IdProducto);
            // Validación de Stock (asumiendo que el DTO tiene el Stock máximo)
            if (nuevaCantidad > producto.Stock)
            {
                MessageBox.Show("¡No hay stock suficiente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (nuevaCantidad <= 0)
            {
                RemoverItem(item);
                return;
            }

            item.Cantidad = nuevaCantidad;
            ActualizarInterfaz();
        }

        private void RemoverItem(ItemVentaDto item)
        {
            var result = MessageBox.Show($"¿Quitar {item.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _items.Remove(item);
                ActualizarInterfaz();
            }
        }

        private void ActualizarInterfaz()
        {
            RefrescarGrilla();
            ActualizarTotal();
        }

        private void grpCargaProductos_Enter(object sender, EventArgs e)
        {
            if(cmdAgregar.Enabled == false)
            {
                MessageBox.Show("Seleccione un cliente para agregar productos");
            }
        }
    }
}
