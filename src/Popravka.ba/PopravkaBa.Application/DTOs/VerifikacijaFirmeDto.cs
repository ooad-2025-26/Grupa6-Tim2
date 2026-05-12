using System.ComponentModel.DataAnnotations;

namespace PopravkaBa.Application.DTOs
{
    // TODO Biznis pravilo duzina stringova
    public class PodnesiVerifikacijuDto
    {
        [Required(ErrorMessage = "Naziv firme je obavezan.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string NazivFirme { get; set; }

        [Required(ErrorMessage = "Sjedište firme je obavezno.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string SjedisteFirme { get; set; }

        [Required(ErrorMessage = "Kontakt telefon je obavezan.")]
        [Phone(ErrorMessage = "Unesite validan broj telefona.")]
        public string KontaktTelefon { get; set; }
   
        [Required(ErrorMessage = "Ime i prezime odgovorne osobe je obavezno.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string OdgovornaOsobaIme { get; set; }

        [Required(ErrorMessage = "Ime i prezime odgovorne osobe je obavezno.")]
        //    [StringLength(xmax, MinimumLength = x, ErrorMessage = "Opis mora biti između x i xmax karaktera.")]
        public string OdgovornaOsobaPrezime { get; set; }

        [Required(ErrorMessage = "Email odgovorne osobe je obavezan.")]
        [EmailAddress(ErrorMessage = "Unesite validnu email adresu.")]
        public string OdgovornaOsobaEmail { get; set; }

        [Required(ErrorMessage = "Pozicija odgovorne osobe je obavezna.")]
        public string OdgovornaOsobaPozicija { get; set; }

        [Required(ErrorMessage = "Telefon odgovorne osobe je obavezan.")]
        [Phone(ErrorMessage = "Unesite validan broj telefona.")]
        public string OdgovornaOsobaTelefon { get; set; }

        // File upload paths — set by the service after saving uploaded files
        [Required(ErrorMessage = "Porezno uvjerenje je obavezno.")]
        public string PoreznoUvjerenje { get; set; }

        public string? LicencaDjelatnosti { get; set; }

        [Required(ErrorMessage = "Logotip firme je obavezan.")]
        public string Logotip { get; set; }

        public string? RadnoVrijeme { get; set; }

        [Url(ErrorMessage = "Unesite validnu URL adresu.")]
        public string? WebStranica { get; set; }
    }

    public class ObradiVerifikacijuDto
    {
        [Required]
        public int VerifikacioniID { get; set; }

        [Required]
        public bool Odobri { get; set; }

        public string? Napomena { get; set; }
    }

 
}
