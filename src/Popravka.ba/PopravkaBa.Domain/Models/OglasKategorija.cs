

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopravkaBa.Domain.Models
{
    public class OglasKategorija
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Oglas")]
        public int OglasID { get; set; }
        public Oglas Oglas { get; set; }
        [ForeignKey("Kategorija")]
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
