using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PopravkaBa.Domain.Models;
namespace Popravka.ba.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<EmailNotifikacijaOglas> emailNotifikacijaOglasi   { get; set; }
        public DbSet<Firma> Firme { get; set; }

        public DbSet<IzvrsilacKategorija> IzvrsilacKategorija { get; set; }
        public DbSet<IzvrsilacUsluge> IzvrsiociUsluge { get; set; }

        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }

        public DbSet<KorisnikMjesto> KorisnikMjesto { get; set; }
        public DbSet<Majstor> Majstori { get; set; }
        public DbSet<Mjesto> Mjesta { get; set; }
        public DbSet<NotifikacijaOglas> NotifikacijeOglasi { get; set; }
        public DbSet<Oglas> Oglasi { get; set; }
        public DbSet<OglasKategorija> OglasKategorije { get; set; }

        public DbSet<OglasMajstora> OglasiMajstora { get; set; }
        public DbSet<OglasRadnoMjesto> OglasiRadnogMjesta { get; set; }

        public DbSet<OglasUsluge> OglasiUsluga { get; set; }

        public DbSet<OglasVozackaDozvola> OglasVozackeDozvole { get; set; }
        public DbSet<PonudaUsluge> PonudeUsluge { get; set; }

        public DbSet<PortfolioSlika> PortfolioSlika { get; set; }
        public DbSet<PrijavaRadnoMjesto> PrijaveRadnoMjesto { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        
        public DbSet<UvjetOglasa> UvjetiOglasa { get; set; }
        public DbSet<VerifikacijaFirme> VerifikacijaFirme { get; set; }

        
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EmailNotifikacijaOglas>().ToTable("EmailNotifikacijaOglas");
            builder.Entity<IzvrsilacKategorija>().ToTable("IzvrsilacKategorija");
            builder.Entity<Kategorija>().ToTable("Kategorija");
            builder.Entity<KorisnikMjesto>().ToTable("KorisnikMjesto");
            builder.Entity<Mjesto>().ToTable("Mjesto");
            builder.Entity<NotifikacijaOglas>().ToTable("NotifikacijaOglas");
            builder.Entity<Oglas>().ToTable("Oglas");
            builder.Entity<OglasKategorija>().ToTable("OglasKategorija");
            builder.Entity<OglasMajstora>().ToTable("OglasMajstora");
            builder.Entity<OglasRadnoMjesto>().ToTable("OglasRadnoMjesto");
            builder.Entity<OglasUsluge>().ToTable("OglasUsluge");
            builder.Entity<OglasVozackaDozvola>().ToTable("OglasVozackaDozvola");
            builder.Entity<PonudaUsluge>().ToTable("PonudaUsluge");
            builder.Entity<PortfolioSlika>().ToTable("PortfolioSlika");
            builder.Entity<PrijavaRadnoMjesto>().ToTable("PrijavaRadnoMjesto");
            builder.Entity<Recenzija>().ToTable("Recenzija", t => t.HasCheckConstraint("CK_Recenzija_Ocjena", "Ocjena >= 1 AND Ocjena <= 5"));
            builder.Entity<UvjetOglasa>().ToTable("UvjetOglasa");
            builder.Entity<VerifikacijaFirme>().ToTable("VerifikacijaFirme");
            

        }
    }
}
