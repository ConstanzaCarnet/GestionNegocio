using GestionApp.src.Data;
using GestionApp.src.DTOs.Request;
using GestionApp.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GestionApp.src.Services
{
    public class PagoService
    {

        public void RegistrarPago(CrearPagoDto dto)
        {
            //valido monto
            if (dto.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero");
            if (dto.MetodoPago == null)
                throw new ArgumentNullException("El metodo de pago debe colocarse");
            //abro conexion
            using var db = new AppDbContext();
            //busco la cuenta del cliente
            var cuenta = db.CuentasCorrientes
                .FirstOrDefault(c => c.IdCliente == dto.IdCliente);
            //verifico que esté la cuenta
            if (cuenta == null)
                throw new Exception("Cuenta no encontrada");
            //Creamos el pago
            var pago = new Pago(dto.IdCliente, dto.Monto, dto.MetodoPago);
            //registramos el pago en la cuenta a través del dominio:
            //valida que no exceda la deuda, descuenta el saldo y lo agrega a la colección de pagos.
            cuenta.RegistrarPago(pago);
            //guardo (EF persiste el pago a través de la cuenta, que está siendo trackeada)
            db.SaveChanges();
        }

        //mostrar todos los pagos
        public List<Pago> Mostrar()
        {
            using var db = new AppDbContext();
            return db.Pagos
                .AsNoTracking()
                .Select(p => new Pago
                {
                    IdPago = p.IdPago,
                    IdCliente = p.IdCliente,
                    MetodoPago = p.MetodoPago,
                    Monto = p.Monto,
                    Fecha = p.Fecha,
                }).ToList();
        }

        //buscar pagos por IdCliente
        public List<Pago> BuscarPorIdCliente(int id)
        {
            using var db = new AppDbContext();
            return db.Pagos
                .Where(c => c.IdCliente == id)
                .Select(p => new Pago
                {
                    IdPago = p.IdPago,
                    IdCliente = p.IdCliente,
                    MetodoPago = p.MetodoPago,
                    Monto = p.Monto,
                    Fecha = p.Fecha
                }).ToList();
        }
        //buscar pagos por mes (1-12)
        public List<Pago> BuscarPorMes(int? mes)
        {
            if (mes == null) return new List<Pago>();
            using var db = new AppDbContext();
            return db.Pagos
                .Where(c => c.Fecha.Month == mes.Value)
                .Select(p => new Pago
                {
                    IdPago = p.IdPago,
                    IdCliente = p.IdCliente,
                    MetodoPago = p.MetodoPago,
                    Monto = p.Monto,
                    Fecha = p.Fecha
                }).ToList();
        }

        //obtener metodos de pago, lo hacemos aquí mismo porque es un enum y no una tabla en la base de datos, así evitamos crear un service innecesario para esto
        public List<string> ObtenerMetodosPago()
        {
            return Enum.GetNames(typeof(MetodoPago)).ToList();
        }

    }
}
