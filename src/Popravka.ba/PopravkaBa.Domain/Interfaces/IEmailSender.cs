using PopravkaBa.Domain.Models;

namespace PopravkaBa.Domain.Interfaces
{
    public interface IEmailSender
    {
        Task PosaljiEmailAsync(string primalac, string subjekt, string tijelo);
        Task PosaljiEmailAsync(EmailNotifikacijaOglas notifikacija);
        Task PosaljiEmailAsync(EmailVerifikacijaFirme verifikacija, bool zaAdmina);
    }
}
