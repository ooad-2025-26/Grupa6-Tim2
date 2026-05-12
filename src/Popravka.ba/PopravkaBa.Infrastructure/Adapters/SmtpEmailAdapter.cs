using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Models;

namespace PopravkaBa.Infrastructure.Adapters
{
    public class SmtpEmailAdapter : IEmailSender
    {

        public SmtpEmailAdapter()
        {
       
        }

        public async Task PosaljiEmailAsync(string primalac, string subjekt, string tijelo)
        {
           
        }

        public Task PosaljiEmailAsync(EmailNotifikacijaOglas notifikacija)
            => PosaljiEmailAsync(notifikacija.EmailPrimalac, "Obavijest o oglasu", notifikacija.FormatIntoEmail());

        public Task PosaljiEmailAsync(EmailVerifikacijaFirme verifikacija, bool zaAdmina)
        {
            var primalac = zaAdmina ? verifikacija.AdminEmail : verifikacija.Firma.Email;
            var subjekt = zaAdmina ? $"Zahtjev za verifikaciju firme: {verifikacija.NazivFirme}" : "Odgovor: Zahtjev za verifikaciju firme na Popravka.ba";
            return PosaljiEmailAsync(primalac, subjekt, verifikacija.FormatIntoEmail(zaAdmina));
        }
    }
}
