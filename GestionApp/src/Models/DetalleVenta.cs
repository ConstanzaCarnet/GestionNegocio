using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    //cree el detalle de venta a parte, pensando en un ticket, tenemos la venta entera y por dentro, el detalle de cada cosa
    public class DetalleVenta
    {
        private int IdDetalle;
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } //relacion con venta, un detalle pertenece a una venta
        public int IdProducto { get; set; }
        public Producto Producto { get; set; } //con esto podemos acceder a los datos del producto desde el detalle de venta, como el nombre o el precio
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        //al ser detalle de venta, tenemos el Subtotal
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public DetalleVenta() { }

        //método
        public DetalleVenta(int idProducto, int cantidad, decimal precioUnitario)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public void CambiarCantidad(int cantidad, bool aumentar)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            if (aumentar)
            {
                Cantidad += cantidad;
            }
            else
            {
                Cantidad -= cantidad;
                if (Cantidad < 0) Cantidad = 0;
            }
            if (Cantidad == 0)
            {
             //elimino
            }
        }

    }
}
