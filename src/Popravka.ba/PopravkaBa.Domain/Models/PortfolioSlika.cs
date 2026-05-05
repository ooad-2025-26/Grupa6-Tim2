

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopravkaBa.Domain.Models
{
    public class PortfolioSlika
    {
        [Key]
        public int PortfolioSlikaID { get; set; }

        [ForeignKey("IzvrsilacUsluge")]
        public string IzvrsilacID { get; set; }
        public IzvrsilacUsluge Izvrsilac { get; set; }
        public string URL { get; set; }
        public string? Opis { get; set; }

    }
}
