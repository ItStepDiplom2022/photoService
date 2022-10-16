using Microsoft.Extensions.Configuration;
using PhotoService.BLL.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PhotoService.BLL.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailAddress _myMailAddress;
        private readonly string _server;
        private readonly int _port;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _myMailAddress = new MailAddress(_configuration.GetSection("SmtpCredentials").GetSection("Email").Value);
            _server = _configuration.GetSection("SmtpCredentials").GetSection("Server").Value;
            _port = int.Parse(_configuration.GetSection("SmtpCredentials").GetSection("Port").Value);
        }

        public async Task SendEmail(string toEmail, string subject, string htmlBody)
        {
            MailAddress to = new MailAddress(toEmail);
            MailMessage m = new MailMessage(_myMailAddress, to)
            {
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };

            using (SmtpClient smtp = new SmtpClient(_server, _port))
            {
                smtp.Credentials = new NetworkCredential(
                    _configuration.GetSection("SmtpCredentials").GetSection("Email").Value,
                    _configuration.GetSection("SmtpCredentials").GetSection("Password").Value);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
            }
        }
    }
}
