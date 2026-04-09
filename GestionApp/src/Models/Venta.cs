using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class Venta
    {
        public int IdVenta;
        public DateTime Fecha { get; private set; } = DateTime.Now;
        public int IdCliente { get; private set; }
        public Cliente Cliente { get; private set; }//relacion con cliente, una venta pertenece a un cliente
        public string MetodoPago { get; private set; }
        //una venta puede tener varios detalles de venta, por lo que se tiene una relación de uno a muchos entre venta y detalle de venta
        public List<DetalleVenta> _detalles = new List<DetalleVenta>();
        //exponemos los detalles de venta como una colección de solo lectura, para evitar que se modifiquen desde fuera de la clase Venta, y así mantener la integridad de los datos
        public IReadOnlyCollection<DetalleVenta> Detalles => _detalles;

        public decimal MontoTotal { get; private set; }
    

        //Constructor necesario para EF(Entity Framework)
        //sin parametros, me permite crear una instancia de la clase Venta sin necesidad de pasarle argumentos, lo cual es útil para EF cuando carga los datos desde la base de datos y necesita crear objetos sin conocer los detalles de su construcción.
        public Venta() { }

        //Constructor para crear una nueva venta.
        public Venta(int clienteId, string metodoPago)
        {
            if(clienteId <= 0)
            {
                throw new ArgumentException("El cliente no puede ser nulo o tener un Id inválido.");
            }
            if(string.IsNullOrWhiteSpace(metodoPago))
            {
                throw new ArgumentException("El método de pago no puede ser nulo o vacío.");
            }

            Cliente = new Cliente { IdCliente = clienteId };
            MetodoPago = metodoPago;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {

            if (producto == null)
                throw new Exception("Producto inválido");

            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            if (producto.Stock < cantidad)
                throw new Exception("Stock insuficiente");
            
            bool aumentarCantidad = true;

            var detalleExistente = _detalles
                .FirstOrDefault(d => d.IdProducto == producto.IdProducto);


            if (detalleExistente != null)
            {
                detalleExistente.CambiarCantidad(cantidad, aumentarCantidad);
            }
            else
            {
                var detalle = new DetalleVenta(
                    producto.IdProducto,
                    cantidad,
                    producto.PrecioVenta
                );

                _detalles.Add(detalle);
            }

            producto.DescontarStock(cantidad);

            RecalcularTotal();
        }

        //recalculamos el total cada vez que se agrega un producto, para mantenerlo actualizado
        private void RecalcularTotal()
        {
            MontoTotal = _detalles.Sum(d => d.Subtotal);
        }



    }

}