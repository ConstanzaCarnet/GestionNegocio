using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Response
{
    public class VentaListDto
    {
        public int IdVenta { get; set; }
        public string Cliente { get; set; }
        public string? Email {  get; set; }
        public string? Telefono { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
