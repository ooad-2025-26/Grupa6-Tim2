using System.ComponentModel.DataAnnotations;

namespace PopravkaBa.Application.DTOs
{
    public class KreirajPrijavaRadnoMjestoDto
    {
        [Required]
        public int OglasID { get; set; }

        [Required]
        public string MajstorID { get; set; }
    }
}
