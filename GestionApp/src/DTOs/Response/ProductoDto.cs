using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Response
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string? Categoria { get; set; }
    }
}
