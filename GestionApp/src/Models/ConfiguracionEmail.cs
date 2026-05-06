using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Models
{
    //Esta clase será utilizada  para configurar los datos de conexión de Mailkit
    public class ConfiguracionEmail
    {
        public int Id { get; set; }
        public string EmailEmisor { get; set; } = string.Empty;
        public string Password{ get; set; } = string.Empty; //Aqui irá la contraseña de la cuenta de correo que se usará para enviar los emails, es importante que esta cuenta tenga habilitada la opción de "Permitir aplicaciones menos seguras" o use una contraseña de aplicación si tiene 2FA habilitado.
        public string Host { get; set; } = "smtp.gmail.com";
        public int Puerto { get; set; } = 587;
        public string NombreEmpresa { get; set; } = "ARIES BUSINESS";
    }
}
