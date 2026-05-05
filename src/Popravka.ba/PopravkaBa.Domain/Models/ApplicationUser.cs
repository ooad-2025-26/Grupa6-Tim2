using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
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
