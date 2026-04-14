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
        // conexion a base de datos            
        //AppDbContext _context = new AppDbContext();---> en lugar de esto, usamos inyeccion de dependemcias
        private readonly AppDbContext _context;
        public CuentaCorrienteServices(AppDbContext context)
        {
            _context = context;
        }

        //metodos del Service
        public CuentaCorriente ObtenerPorCliente(int clienteId)
        {
            //uso los métodos de EF para buscar el clietne y retornarlo
            return _context.CuentasCorrientes
                .First(c => c.IdCliente == clienteId);
        }

        public decimal ObtenerSaldo(int clienteId)
        {
            return _context.CuentasCorrientes
                .Where(c => c.IdCliente == clienteId)
                .Select(c => c.Saldo)
                .First();
        }
    }
}
