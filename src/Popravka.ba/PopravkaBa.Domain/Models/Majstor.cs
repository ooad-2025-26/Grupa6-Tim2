
using Microsoft.AspNetCore.Identity;

namespace PopravkaBa.Domain.Models
{
    public class Majstor : IzvrsilacUsluge
    {
        public ICollection<PrijavaRadnoMjesto>? PrijaveZaRadnoMjesto { get; set; }

    }
}
