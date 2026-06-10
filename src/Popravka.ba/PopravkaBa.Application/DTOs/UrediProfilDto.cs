using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PopravkaBa.Application.DTOs
{
    // Zajednička polja koja dijele i Majstor i Firma
    public class UrediProfilDto
    {
        public string Id { get; set; } = "";

        [Display(Name = "Ime")]
        [MaxLength(50, ErrorMessage = "Ime ne smije biti duže od 50 karaktera.")]
        public string? Ime { get; set; }

        [Display(Name = "Prezime")]
        [MaxLength(50, ErrorMessage = "Prezime ne smije biti duže od 50 karaktera.")]
        public string? Prezime { get; set; }

        [Display(Name = "O meni (kratki opis)")]
        [MaxLength(1000, ErrorMessage = "Opis ne smije biti duži od 1000 karaktera.")]
        public string? Opis { get; set; }

        [Display(Name = "Adresa")]
        [MaxLength(200)]
        public string? Adresa { get; set; }

        [Display(Name = "Minimalna cijena usluge (KM)")]
        [Range(0, 10000, ErrorMessage = "Cijena mora biti između 0 i 10000.")]
        public int? MinCijenaUsluge { get; set; }

        // Govori view-u da li prikazuje polja specifična za firmu
        public bool JeFirma { get; set; }

        // Firma-specifična polja — popunjavaju se samo ako je JeFirma = true
        [Display(Name = "Naziv firme")]
        [MaxLength(100)]
        public string? NazivFirme { get; set; }

        [Display(Name = "Web stranica")]
        [MaxLength(200)]
        [Url(ErrorMessage = "Unesite ispravnu URL adresu (npr. https://example.com).")]
        public string? WebStranica { get; set; }

        [Display(Name = "Radno vrijeme (npr. Pon-Pet 08:00-16:00)")]
        [MaxLength(100)]
        public string? RadnoVrijeme { get; set; }
    }
}
