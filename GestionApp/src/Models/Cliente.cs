using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Models;
//para usar elementos de form
using System.Windows.Forms;


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
        //CLINTE 1 ---> 1 CUENTA
        public CuentaCorriente Cuenta { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string email, string telefono, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
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
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
        }

        // Validación básica de teléfono: nos quedamos con los dígitos y exigimos
        // una longitud razonable (8 a 15, según el estándar E.164). Acepta espacios,
        // guiones, paréntesis y el prefijo "+".
        public static bool TelefonoEsValido(string? telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return false;
            int cantidadDigitos = telefono.Count(char.IsDigit);
            return cantidadDigitos >= 8 && cantidadDigitos <= 15;
        }

        public  void Desactivar()
        {
            Estado = "Inactivo";
        }
         public void Activar()
        {
            Estado = "Activo";
        }

        
    }
}
