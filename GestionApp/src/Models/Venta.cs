using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdCliente { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoTotal { get; set; }
        public Cliente Cliente { get; set; }//relacion con cliente, una venta pertenece a un cliente
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
