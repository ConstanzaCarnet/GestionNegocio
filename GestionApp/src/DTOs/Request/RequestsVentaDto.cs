using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Request
{
    public class CrearVentaDto
    {
        public int IdCliente { get; set; }
        public List<CrearDetalleDto> Items { get; set; } = new();
    }
}
