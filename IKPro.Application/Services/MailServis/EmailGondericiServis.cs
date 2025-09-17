using System.Net.Mail;
using System.Net;

namespace IKPro.Application.Services.MailServis
{
    public class EmailGondericiServis : IEmailGondericiServis
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly string _smtpUsername = "kadircaganzengin@gmail.com";
        private readonly string _smtpPassword = "qocx meaf yvqt shwz";
        private readonly int _smtpPort = 587;
        public async Task EmailGonderAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
            }
        }
       
        public string GenerateRandomPassword()
        {
            var random = new Random();

            var length = 8;


            string kucukHarf = "abcdefghijklmnopqrstuvwxyz";
            string buyukHarf = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sayi = "1234567890";
            string ozelKarakter = "!@#$%^&*()";

            char[] password = new char[length];
            password[0] = kucukHarf[random.Next(kucukHarf.Length)];
            password[1] = buyukHarf[random.Next(buyukHarf.Length)];
            password[2] = sayi[random.Next(sayi.Length)];
            password[3] = ozelKarakter[random.Next(ozelKarakter.Length)];

            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

            for (int i = 4; i < length; i++)
            {
                password[i] = validChars[random.Next(validChars.Length)];
            }

            password = password.OrderBy(x => random.Next()).ToArray();

            return new string(password);
        }
    }
}
