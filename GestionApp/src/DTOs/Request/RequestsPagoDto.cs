using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Models;

namespace GestionApp.src.DTOs.Request
{
    public class CrearPagoDto
    {
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
