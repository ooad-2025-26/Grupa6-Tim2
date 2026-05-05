using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace PopravkaBa.Domain.Models
{
    public class Kategorija
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }


    }
}
