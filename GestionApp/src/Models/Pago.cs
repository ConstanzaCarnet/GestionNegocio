using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public DateTime Fecha { get; set; }

        public Pago() { }

        public Pago(int idCliente, decimal monto, string metodoPago)
        {
            IdCliente = idCliente;
            Monto = monto;
            MetodoPago = metodoPago;
            Fecha = DateTime.Now;
        }

    }

}
