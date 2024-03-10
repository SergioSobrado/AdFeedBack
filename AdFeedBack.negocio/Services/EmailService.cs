using AdFeedBack.negocio.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Reflection;

namespace AdFeedBack.negocio.Services
{
    // Se implementa la interfaz IEmailService para poder enviar correos electrónicos
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, Dictionary<string, string> templateVariables)
        {
            // Se obtiene la ruta del archivo Confirmation.html
            var templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "../EmailTemplates/Confirmation.html");
            
            // Se lee el contenido del archivo Confirmation.html
            var templateContent = File.ReadAllText(templatePath);

            // Se reemplazan las variables del archivo Confirmation.html con los valores correspondientes
            foreach (var variable in templateVariables)
            {
                templateContent = templateContent.Replace($"{{{{ {variable.Key} }}}}", variable.Value);
            }
            // Se extraen las credencial SMTPEmail/Email del archivo appsettings.json
            var fromEmail = _configuration["SMTPEmail:Email"];
            // Se crea un objeto MailAddress con la dirección de correo electrónico del remitente y el nombre del remitente
            var fromAddress = new MailAddress(fromEmail, "Bryan Araujo");
            // Se crea un objeto MailAddress con la dirección de correo electrónico del destinatario
            var toAddress = new MailAddress(toEmail);
            // Se crea un objeto SmtpClient con el host y el puerto del servidor SMTP
            var fromPassword = _configuration["SMTPEmail:Password"];

            // Se crea un objeto SmtpClient con el host y el puerto del servidor SMTP
            var smtp = new SmtpClient
            {
                Host = "smtp.zoho.com",
                Port = 587, // O 465 si prefieres usar SSL
                EnableSsl = true, // Asegúrate de habilitar SSL o STARTTLS según el puerto que estés utilizando
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            // Se crea un objeto MailMessage con la dirección de correo electrónico del remitente, la dirección de correo electrónico del destinatario, el asunto del correo electrónico y el contenido del correo electrónico
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = templateContent,
                IsBodyHtml = true
            })
            // Se envía el correo electrónico
            {
                smtp.Send(message);
            }
        }
    }
}
