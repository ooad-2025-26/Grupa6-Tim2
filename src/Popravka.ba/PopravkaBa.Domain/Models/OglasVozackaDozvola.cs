using PopravkaBa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Domain.Models
{
    public class OglasVozackaDozvola
    {
        [Key]
        public int ID { get; set; }

        public VozackaDozvola VozackaDozvola { get; set; }

        [ForeignKey("OglasRadnoMjesto")]
        public int OglasID { get; set; }
        public OglasRadnoMjesto Oglas { get; set; }
    }
}
