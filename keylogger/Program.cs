using System;
using System.IO; 
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace keylogger
{
    class Program
    {
        private static LogManager _logManager;
        private static EmailSender _emailSender;
        private const string LogFileName = "log.txt";

        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            string host = config["EmailSettings:Host"];
            int port = int.Parse(config["EmailSettings:Port"]);
            string gondericiMail = config["EmailSettings:SenderEmail"];
            string uygulamaSifresi = config["EmailSettings:SenderPassword"];
            string aliciMail = config["EmailSettings:ReceiverEmail"];
            _logManager = new LogManager(LogFileName);
            _emailSender = new EmailSender(host, port, gondericiMail, uygulamaSifresi, aliciMail);

            Console.WriteLine("Lütfen göndermek istediğiniz metni yazın ve ardından Enter'a basın:");
            string yazilanMetin = Console.ReadLine();
            _logManager.LogKey(yazilanMetin);
            Console.WriteLine("Metin log.txt dosyasına kaydedildi.");
            Console.WriteLine("E-posta gönderiliyor...");
            try
            {
                await _emailSender.SendLogFileAsEmailAsync(LogFileName);
                Console.WriteLine("E-posta başarıyla gönderildi.");
                File.Delete(LogFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderilemedi: {ex.Message}");
            }

            Console.WriteLine("\nİşlem tamamlandı. Kapatmak için herhangi bir tuşa basın...");
            Console.ReadKey();
        }
    }
}