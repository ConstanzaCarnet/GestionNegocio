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
        public string Estado { get; set; } = "Activo"; //me servirá para el envío de catálogo y mensajería personalizada
        public List<Venta> Ventas { get; set; } = new List<Venta>();

        private List<CuentaCorriente> _movimientos = new();
        public IReadOnlyCollection<CuentaCorriente> Movimientos => _movimientos;

        public Cliente() { }

        public Cliente(string nombre, string email, int telefono)
        {
            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede ser nulo o vacío.");
            }
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email del cliente no puede ser nulo o vacío.");
            }
            //BUSCAR LIBRERÍA PARA VALIDAR TELEFONO CORRECTAMENTE!!!!!
            Nombre = nombre;
            Email = email;
            Telefono = telefono.ToString();
        }
        
        public void CambiarDatos(string nombre, string? apellido, string? email, string telefono, string? direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede ser nulo o vacío.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email del cliente no puede ser nulo o vacío.");
            }
            //BUSCAR LIBRERÍA PARA VALIDAR TELEFONO CORRECTAMENTE!!!!!
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
        }

        public  void Desactivar()
        {
            Estado = "Inactivo";
        }
         public void Activar()
        {
            Estado = "Activo";
        }
        public decimal CalcularSaldo()
        {
            return _movimientos.Sum(m =>
                m.Tipo == "CARGO" ? m.Monto : -m.Monto);
        }

    }
}
