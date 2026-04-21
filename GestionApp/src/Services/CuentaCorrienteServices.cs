using GestionApp.src.Data;
using GestionApp.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services
{
    public class CuentaCorrienteServices
    {

        //metodos del Service
        public CuentaCorriente ObtenerPorCliente(int clienteId)
        {
            using var db = new AppDbContext();
            return db.CuentasCorrientes
                .First(c => c.IdCliente == clienteId);
        }

        public decimal ObtenerSaldo(int clienteId)
        {
            using var db = new AppDbContext();
            return db.CuentasCorrientes
                .Where(c => c.IdCliente == clienteId)
                .Select(c => c.Saldo)
                .First();
        }
    }
}
