

using PopravkaBa.Domain.Enums;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopravkaBa.Domain.Models
{
    public class OglasRadnoMjesto : Oglas
    {
        public int BrojIzvrsilaca { get; set; } = 1;
        public ICollection<OglasVozackaDozvola> VozackeDozvole { get; set; }
        public ICollection<UvjetOglasa> Uvjeti { get; set; }
        public ICollection<PrijavaRadnoMjesto> Prijave { get; set; }

        public VrstaZaposlenja VrstaZaposlenja { get; set; }
        public int MinPrihod { get; set; } = 0;
        public int MaxPrihod { get; set; } = 0;
        public TipIsplate TipIsplate { get; set; }
        public int BrojPrijava { get; set; } = 0;
        public override void DodajKategoriju(Kategorija kategorija)
        {
            
        }

        public override void UkloniKategoriju(int kategorijaID)
        {
            
        }
        public void DodajUvjet(string uvjet)
        {

        }
        public void UkloniUvjet(int uvjetID)
        {

        }
        public void DodajPrijavu(PrijavaRadnoMjesto prijava)
        {

        }
        public void UkloniPrijavu(int prijavaID)
        {

        }

    }
}
