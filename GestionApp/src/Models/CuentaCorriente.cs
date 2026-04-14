using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class CuentaCorriente
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } //relacion con cliente, un movimiento de cuenta corriente pertenece a un cliente
        public decimal Saldo { get; set; } //saldo actual de la cuenta corriente, se actualiza con cada movimiento registrado
        //public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();

        public CuentaCorriente() { }

        public CuentaCorriente(int idCliente)
        {
            IdCliente = idCliente;
        }

        // metodo para registrar pago
        public void RegistrarPago(Pago pago)
        {
            if (pago == null)
                throw new Exception("Pago inválido");

            if (pago.Monto > Saldo)
                throw new Exception("El pago excede la deuda actual");

            Saldo -= pago.Monto;
            Pagos.Add(pago);
        }
        //cambios en el saldo
        //aplico cargo
        public void AplicarCargo(decimal cargo)
        {
            if(cargo <= 0)
                throw new Exception();
            
            Saldo+= cargo;
        }
        
        //aplicar pago
        public void AplicarPago(decimal pago)
        {
            if (pago <= 0)
                throw new Exception();

            if (pago > Saldo)
                throw new Exception();

            Saldo -= pago;
        }
    }
}
