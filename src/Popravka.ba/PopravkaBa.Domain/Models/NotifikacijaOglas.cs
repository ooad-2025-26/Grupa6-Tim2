

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopravkaBa.Domain.Models
{
    public abstract class NotifikacijaOglas
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Oglas")]
        public int OglasID { get; set; }
        public Oglas Oglas { get; set; }

        public DateTime DatumSlanja { get; set; }

        public string Tekst { get; set; }

    }
}
