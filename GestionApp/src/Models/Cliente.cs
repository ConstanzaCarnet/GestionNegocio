using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Activo"; //me servirá para el envío de catálogo
        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public List<CuentaCorriente> CuentasCorrientes { get; set; } = new List<CuentaCorriente>();
    }
}
