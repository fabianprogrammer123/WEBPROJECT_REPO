using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using WEBPROJECT;

namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        // not using secret keys anymore - now sendgrid Key
        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var apiKey2 = ""; // SENDGRID KEY
            var client = new SendGridClient(apiKey2);
            var from = new EmailAddress("presentation-tools@DONOTREPLY", "Presentation-Tools");
            var to = new EmailAddress(email, "Customer");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            return client.SendEmailAsync(msg);
        }
    }
}