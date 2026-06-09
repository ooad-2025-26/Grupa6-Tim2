namespace PopravkaBa.Application.DTOs
{
    public class ProfilIzvrsilacDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string? Slika { get; set; }
        public string? Opis { get; set; }
        public string? Lokacija { get; set; }
        public decimal ProsjecnaOcjena { get; set; }
        public int BrojRecenzija { get; set; }
        public int BrojZavrsenihPoslova { get; set; }
        public int? MinCijenaUsluge { get; set; }
        public bool JeMajstor { get; set; }

        // Majstor-specifično
        public int? GodinaIskustva { get; set; }

        // Firma-specifično
        public string? WebStranica { get; set; }
        public string? RadnoVrijeme { get; set; }
        public string? VelicinaFirme { get; set; }

        public List<string> Kategorije { get; set; } = new();
        public List<PortfolioSlikaDto> SlikePortfolija { get; set; } = new();
        public List<OglasMajstoraListDto> OglasiMajstora { get; set; } = new();
        public List<RecenzijaProfilDto> Recenzije { get; set; } = new();
    }

    public class PortfolioSlikaDto
    {
        public string URL { get; set; }
        public string? Opis { get; set; }
    }

    public class OglasMajstoraListDto
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string? Opis { get; set; }
        public int MinCijena { get; set; }
        public string TipIsplate { get; set; }
        public string? Lokacija { get; set; }
    }

    public class RecenzijaProfilDto
    {
        public string KlijentIme { get; set; }
        public string? KlijentSlika { get; set; }
        public int Ocjena { get; set; }
        public string? Komentar { get; set; }
        public DateTime DatumRecenzije { get; set; }
    }
}