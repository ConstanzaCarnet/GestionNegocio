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
        public int IdDetalle { get; private set; }
        public int IdVenta { get; private set; }
        public Venta Venta { get; private set; }
        public int IdProducto { get; private set; }
        public Producto Producto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;


        private DetalleVenta() { }

        //método
        public DetalleVenta(int idProducto, int cantidad, decimal precio)
        {
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precio;
        }
        //método para aumentar cantidad
        public void AumentarCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            Cantidad += cantidad;
        }
        //disminuir cantidad
        public void DisminuirCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");
            if (Cantidad < cantidad)
                throw new Exception("Cantidad a disminuir mayor a la cantidad actual");
            Cantidad -= cantidad;
        }

    }
}
