using System.ComponentModel.DataAnnotations;

namespace PopravkaBa.Application.DTOs
{
    public class KreirajPonudaUslugeDto
    {
        [Required]
        public int OglasUslugeID { get; set; }

        [Required(ErrorMessage = "Datum početka usluge je obavezan.")]
        public DateTime DatumPocetkaUsluge { get; set; }

        public DateTime? DatumOcekivanogZavrsetka { get; set; }

        // TODO Da li limitarmo poruku na 500?
        [StringLength(500, ErrorMessage = "Poruka ne može biti duža od 500 karaktera.")]
        public string? Poruka { get; set; }
    }

    public class UrediPonudaUslugeDto
    {
        // TODO Ako implementirali uređivanje ponuda, potrebno kreirati i DTO za uređivanje. DATATRANSFEROBJECTS
    }
}
