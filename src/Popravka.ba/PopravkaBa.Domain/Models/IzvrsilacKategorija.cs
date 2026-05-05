using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Domain.Models
{
    public class IzvrsilacKategorija
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("IzvrsilacUsluge")]
        public string IzvrsilacID { get; set; }
        public IzvrsilacUsluge Izvrsilac { get; set; }

        [ForeignKey("Kategorija")]
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
