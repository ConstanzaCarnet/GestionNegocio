using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Request
{
    public class CrearProductoDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; } 
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
    }
    public class ActualizarProductoDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal? PrecioCompra { get; set; }
        public int Stock { get; set; }//hay stock que puede vencerse(como las cremas o los labiales) por eso permito que el usuario poueda modificar el stock
        public int IdCategoria { get; set; }
    }
}
