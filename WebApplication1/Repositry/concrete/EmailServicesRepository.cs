using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using WebApplication1.Model.Dto;
using WebApplication1.Model.Entity;
using WebApplication1.Repositry.Contract;

namespace WebApplication1.Repositry.concrete
{
    public class EmailServicesRepository :IEmailServiceRepository
    {
        private readonly EmailSettings _emailSettings;
        public EmailServicesRepository(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void SendEmail(EmailservicesDto emailservicesDto)
        {
            using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = emailservicesDto.Subject,
                    Body = emailservicesDto.Body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(emailservicesDto.SenderEmail);
                
                client.Send(mailMessage);
            }
        }

    }
}
