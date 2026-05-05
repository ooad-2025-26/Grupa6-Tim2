
using Microsoft.AspNetCore.Identity;
using PopravkaBa.Domain.Enums;

namespace PopravkaBa.Domain.Models
{
    public class Firma : IzvrsilacUsluge
    {
        public string nazivFirme { get; set; }
        public int minZaposlenih { get; set; } = 1;
        public int maxZaposlenih { get; set; } = 5;
        private string? JIB { get; set; }
        public Status statusVerifikacije { get; set; } = Status.NaCekanju;

        public string? radnoVrijeme;
        public string? webStranica;
        public DateOnly datumOsnivanja;

    }
}
