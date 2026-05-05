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

        public DbSet<Firma> Firme { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<IzvrsilacUsluge> IzvrsiociUsluge {  get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Kategorija>().ToTable("Kategorija");
            
        }
    }
}
