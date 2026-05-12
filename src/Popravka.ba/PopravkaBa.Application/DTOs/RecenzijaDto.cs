using System.ComponentModel.DataAnnotations;

namespace PopravkaBa.Application.DTOs
{
    // TODO Biznis pravilo duzina stringova
    public class KreirajRecenzijuDto
    {
        [Required]
        public string IzvrsilacID { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezna.")]
        [Range(1, 5, ErrorMessage = "Ocjena mora biti između 1 i 5.")]
        public int Ocjena { get; set; }

        [Required(ErrorMessage = "Komentar je obavezan.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string Komentar { get; set; } = string.Empty;
    }

    public class PrijaviRecenzijuDto
    {
        [Required]
        public int RecenzijaID { get; set; }

        [Required(ErrorMessage = "Razlog prijave je obavezan.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string RazlogPrijave { get; set; } = string.Empty;
    }
    public class ObradiPrijavuRecenzijeDto
    {
        [Required]
        public int RecenzijaID { get; set; }

        [Required]
        public bool Obrisi { get; set; }
    }
}
