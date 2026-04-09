using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services
{
    public class CuentaCorrienteServices
    {
        //registro de pago
        public void RegistroPago(int clienteId, decimal monto, int? idVenta = null)
        {
            //inicializar el contexto(conexion) de la base de datos
            using var db = new Data.AppDbContext();
            //crear un nuevo movimiento de cuenta corriente para el pago, llamo el método del modelo CuentaCorriente para registrar el movimiento
            var movimiento = new Models.CuentaCorriente(clienteId, monto, "PAGO", idVenta);
            //agregar el movimiento a la base de datos
            db.CuentasCorrientes.Add(movimiento);
            //guardar los cambios en la base de datos
            db.SaveChanges();
        }
    }
}
