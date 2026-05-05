
using Microsoft.AspNetCore.Identity;

namespace PopravkaBa.Domain.Models
{
    public class Klijent : ApplicationUser
    {
        public ICollection<Recenzija>? Recenzije { get; set; }
     
    }
}
