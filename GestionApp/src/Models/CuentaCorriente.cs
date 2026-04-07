using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class CuentaCorriente
    {
        public int IdMovimiento { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } //relacion con cliente, un movimiento de cuenta corriente pertenece a un cliente
        public DateTime Fecha { get; set; } = DateTime.Now; 
        public decimal Monto { get; set; }
        public int? IdVenta { get; set; } //relacion con venta, un movimiento de cuenta corriente puede estar relacionado con una venta, pero no es obligatorio, puede ser un pago sin venta, o un ajuste manual
        public Venta Venta { get; set; }
    }
}
