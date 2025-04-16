using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ThuQuanServer.Interfaces;

namespace ThuQuanServer.Repository
{
    public class SendOTPRepository : ISendOTPRepository
    {
        private readonly IConfiguration _config;

        public SendOTPRepository(IConfiguration config)
        {
            _config = config;
        }

        public void sendHTMLMessage(string to, string subject, string html)
        {
            string host = _config["Email:Host"];
            int port = int.Parse(_config["Email:Port"]);
            string username = _config["Email:Username"];
            string password = _config["Email:Password"];

            var message = new MailMessage();
            message.From = new MailAddress(username);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = html;
            message.IsBodyHtml = true;

            using var smtp = new SmtpClient(host, port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(username, password)
            };

            smtp.Send(message);
        }
    }
}