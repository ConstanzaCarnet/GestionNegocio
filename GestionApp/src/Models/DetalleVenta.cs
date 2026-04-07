using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } //relacion con venta, un detalle pertenece a una venta
        public int IdProducto { get; set; }
        public Producto Producto { get; set; } //con esto podemos acceder a los datos del producto desde el detalle de venta, como el nombre o el precio
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        //se podría tener MontoTotal, pero en este caso se calcula el monto total de la venta sumando el precio unitario por la cantidad de cada detalle de venta, y luego se guarda el monto total en la tabla de ventas, para evitar tener que calcularlo cada vez que se consulta una venta
    }
}
