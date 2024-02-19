using PortafolioJBR.Infraestructura;
using PortafolioJBR.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortafolioJBR.Servicios
{
    public class ServiceMailSendGrid : IServiceEmailSendGrid
    {
        private readonly IConfiguration _configuration;

        public ServiceMailSendGrid(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task Enviar(ContactoVM contactoVM)
        {
            var apikey = _configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = _configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = _configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apikey);
            var from = new EmailAddress(email, nombre);

            var subject = $"El cliente {contactoVM.Nombre} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTexto = contactoVM.Mensaje;

            var conteidoHtml = $@"De: {contactoVM.Nombre} - Email: {contactoVM.Email} Mensaje: {contactoVM.Mensaje}";
            var singleMail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTexto, conteidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleMail);

        }
    }
}
