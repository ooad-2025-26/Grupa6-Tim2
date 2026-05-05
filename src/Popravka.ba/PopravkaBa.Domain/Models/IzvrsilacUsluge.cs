using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace PopravkaBa.Domain.Models
{
    public abstract class IzvrsilacUsluge : ApplicationUser
    {
        public string adresa { get; set; }
        public string? stambeniBroj { get; set; }
        public Double prosjecnaOcjena { get; set; } = 0.0;
        public int brojZavrsenihPoslova { get; set;  } = 0;
        public string? opis { get; set; }

        public void ZavrsiPosao() { }
        public void DodajKategoriju(Kategorija kategorija) { }
        public void UkloniKategoriju(Kategorija kategorija) { }
    }
}
