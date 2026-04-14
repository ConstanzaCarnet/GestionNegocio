using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Request
{
    public class CrearClienteDto
    {
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string Telefono { get; set; }
        public string? Direccion { get; set; }
    }
    public class ActualizarClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
