using Microsoft.AspNetCore.Identity;

namespace PopravkaBa.Domain.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string? ime { get; set; }
        public string? prezime  { get; set; }
        public DateTime datumRegistracije { get; } = DateTime.Now;
        public string? slika { get; set; }

    }
}
