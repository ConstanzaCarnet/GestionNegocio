using MailKit;
using MailKit.Net.Smtp;//En este caso usamos Package MailKit, se puede por nugget o por consola Install-Package MailKit
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Services.Email;
using System.Security.Authentication;
using GestionApp.src.Models;

namespace GestionApp.src.Services
{
    public class MensajeriaService
    {
        public void EnviarWhatsApp(string telefono, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El cliente no tiene un número de teléfono registrado.");

            // Limpiamos el número de caracteres no numéricos
            string numeroLimpio = new string(telefono.Where(char.IsDigit).ToArray());

            // Formateamos la URL de WhatsApp (usamos api.whatsapp.com para compatibilidad)
            string url = $"https://api.whatsapp.com/send?phone={numeroLimpio}&text={Uri.EscapeDataString(mensaje)}";

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        public void EnviarEmailTextoPlano(string email, string asunto, string cuerpoTexto)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Sin email");

            // Limpiamos el cuerpo para que no tenga caracteres que rompan la URL
            string url = $"mailto:{email}?subject={Uri.EscapeDataString(asunto)}&body={Uri.EscapeDataString(cuerpoTexto)}";

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        //vamos a enviar un mensaje tipo html, que se ve mejor
        //Devuelve Task (no void) para que la vista pueda await-earlo y capturar errores de envío.
        public async Task EnviarEmailHtml(string emailDestino, string asunto, string cuerpoTicket)
        {
            var configService = new ConfiguracionService();
            var config = configService.ObtenerConfig();

            if(string.IsNullOrWhiteSpace(config.EmailEmisor) || string.IsNullOrWhiteSpace(config.Password))
                throw new Exception("La configuración de email no está completa. Por favor, configure el email emisor y la contraseña.");


            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress(config.NombreEmpresa, config.EmailEmisor));
            mensaje.To.Add(new MailboxAddress("", emailDestino));
            mensaje.Subject = asunto;

            // Construimos el cuerpo HTML
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
            <html>
                <body style='font-family: sans-serif; color: #333;'>
                    <h2 style='color: #2c3e50;'>Comprobante de Compra</h2>
                    <p>Estimado cliente, adjuntamos el detalle de su transacción:</p>
                    <pre style='background-color: #f8f9fa; padding: 20px; border-left: 5px solid #2c3e50; font-family: monospace; font-size: 14px;'>
                {cuerpoTicket}
                    </pre>
                    <p style='font-size: 12px; color: #7f8c8d;'>Gracias por elegir a <b>ARIES BUSINESS</b>.</p>
                </body>
            </html>";

            mensaje.Body = bodyBuilder.ToMessageBody();

            using (var cliente = new SmtpClient())
            {
                // Para Gmail: smtp.gmail.com, puerto 587. 
                // IMPORTANTE: Usa una "Contraseña de Aplicación" de Google, no la clave normal.
                await cliente.ConnectAsync(config.Host, config.Puerto, MailKit.Security.SecureSocketOptions.StartTls);
                await cliente.AuthenticateAsync(config.EmailEmisor, config.Password);

                await cliente.SendAsync(mensaje);
                await cliente.DisconnectAsync(true);
            }
        }

        // Método de prueba para verificar la configuración de email
        public async Task ProbarConexion(ConfiguracionEmail config)
        {
            try
            {
                //SmtpClient es la clase que nos permite conectarnos a un servidor SMTP para enviar emails.
                //propia de MailKit, no confundir con System.Net.Mail.SmtpClient que es la clase nativa de .NET pero que tiene limitaciones y no se recomienda para nuevos desarrollos.
                using (var cliente = new SmtpClient())
                {
                    //primero conectamos al servidor, usando StartTLS para seguridad. Si el servidor no soporta StartTLS, podríamos usar SecureSocketOptions.Auto o SecureSocketOptions.SslOnConnect dependiendo del puerto y configuración del servidor.
                    await cliente.ConnectAsync(config.Host, config.Puerto, MailKit.Security.SecureSocketOptions.StartTls);
                    //Intentamos autenticarnos con la clave de aplicación
                    await cliente.AuthenticateAsync(config.EmailEmisor, config.Password);
                    //si llegamos aquí sin excepciones, la conexión y autenticación fueron exitosas. Solo nos queda desconectar.
                    await cliente.DisconnectAsync(true);
                }

            }//verificamos los tipos de excepciones que pueden ocurrir durante la conexión y autenticación para dar mensajes más claros al usuario.
            catch (AuthenticationException)
            {
                throw new Exception("Error de autenticación. Verifique su correo y contraseña.");
            }
            catch (SmtpCommandException ex)
            {
                throw new Exception($"Error en el comando SMTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al probar la conexión: {ex.Message}");
            }
        }
    }
}
