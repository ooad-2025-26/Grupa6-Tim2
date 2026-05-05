
using Microsoft.AspNetCore.Identity;
using PopravkaBa.Domain.Enums;

namespace PopravkaBa.Domain.Models
{
    public class Firma : IzvrsilacUsluge
    {
        public string NazivFirme { get; set; }
        public int MinZaposlenih { get; set; } = 1;
        public int MaxZaposlenih { get; set; } = 5;
        private string? JIB { get; set; }
        public Status StatusVerifikacije { get; set; } = Status.NaCekanju;

        public string? RadnoVrijeme { get; set; }
        public string? WebStranica { get; set; }
        public DateOnly DatumOsnivanja { get; set; }

        public ICollection<VerifikacijaFirme>? ZahtjeviVerifikacije { get; set; }

    }
}
