using System.Net;
using System.Net.Mail;
using users_api.Application.Interfaces;

namespace users_api.Infrastructure.Services
{
    public class EmailService:IEmailService
    {
        // private readonly SmtpClient _client;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
            /* _client = new SmtpClient
            {
                Host = "smtp-server.com", Port = 587, EnableSsl = true, Credentials = new NetworkCredential("user", "password")
            };*/
        }

        public async Task SendEmailAsync(string email, string subject, string content)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@mydomain.com"), Subject = subject, Body = content, IsBodyHtml = true
            };
            
            mailMessage.To.Add(email);
            _logger.LogInformation("Email sent");
            // await _client.SendMailAsync(mailMessage);
        }
    }
}
