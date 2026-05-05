using PopravkaBa.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PopravkaBa.Domain.Models
{
    public class UvjetOglasa
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("OglasRadnoMjesto")]
        public int OglasID { get; set; }
        public OglasRadnoMjesto Oglas { get; set; }

        public string TekstUvjeta { get; set; }
    }
}
