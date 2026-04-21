using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.DTOs.Response
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string? Direccion { get; set; }
        public decimal? Saldo { get; set; }

        public string? NombreCompleto => $"{Nombre} {Apellido}";
    }
}
