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
        public Venta? Venta { get; set; }
        public string Tipo { get; set; } //puede ser "Cargo" o "Pago"

        public CuentaCorriente() { }

        public CuentaCorriente(int idCliente, decimal monto, string tipo, int? idVenta = null)//si no ingresa idVenta, se asume que es un movimiento sin venta asociada, como un pago o un ajuste manual
        {
            IdCliente = idCliente;
            Monto = monto;
            Tipo = tipo.ToUpper();
            IdVenta = idVenta;
        }

        //registrar movimiento nuevo
        public void RegistrarMovimiento(decimal monto, string tipo, int? idVenta = null)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(tipo) || (tipo != "CARGO" && tipo != "PAGO"))//||ADELANTO??
                throw new ArgumentException("El tipo debe ser 'CARGO' o 'PAGO'.");
            Monto = monto;
            Tipo = tipo.ToUpper();
            IdVenta = idVenta;
            Fecha = DateTime.Now; //actualiza la fecha al registrar un nuevo movimiento
        }


    }
}
