using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Response
{
    public class MovimientoDto
    {
        public int IdMovimiento {get; set;}
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string Detalle { get; set; }
    }
}
