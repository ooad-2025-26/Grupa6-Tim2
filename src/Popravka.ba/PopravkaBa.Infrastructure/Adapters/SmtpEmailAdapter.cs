using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PopravkaBa.Application.Services.Interface;

namespace PopravkaBa.Infrastructure.Adapters
{
    public class SmtpEmailAdapter : IEmailSender
    {
        private readonly SmtpSettings _settings;

        public SmtpEmailAdapter(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task PosaljiEmailAsync(string primalac, string subjekt, string tijelo)
        {
            using var klijent = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.KorisnickoIme, _settings.Lozinka),
                EnableSsl = _settings.KoristiSsl
            };

            var poruka = new MailMessage
            {
                From = new MailAddress(_settings.PosiljateljEmail, _settings.PosiljateljIme),
                Subject = subjekt,
                Body = tijelo,
                IsBodyHtml = false
            };
            poruka.To.Add(primalac);

            await klijent.SendMailAsync(poruka);
        }
    }
}
