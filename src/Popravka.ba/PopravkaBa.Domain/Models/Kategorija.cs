
using System.ComponentModel.DataAnnotations;
namespace PopravkaBa.Domain.Models
{
    public class Kategorija
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }


    }
}
