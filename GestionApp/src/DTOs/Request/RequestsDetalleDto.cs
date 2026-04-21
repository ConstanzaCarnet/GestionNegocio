using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Request
{
    //para persistencia
    public class CrearDetalleDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    //solo visual
    public class ItemVentaDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
}
