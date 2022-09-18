using Microsoft.AspNetCore.Mvc.Formatters;
using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailService
    {
        Task Send(ContactViewModel contact);
    }
    public class SendGridEmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(ContactViewModel contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"Mensaje de {contact.Email} recibido desde tu portafolio";
            var to = new EmailAddress(email, name);
            var msg = contact.Message;
            var content = @$"De: {contact.Name} - 
                            Email: {contact.Email}
                            Mensaje: {contact.Message}";

            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, msg, content);
            var response = await client.SendEmailAsync(singleEmail);
        }
    }
}
