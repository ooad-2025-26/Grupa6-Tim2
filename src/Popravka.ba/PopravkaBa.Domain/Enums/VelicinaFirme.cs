using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Domain.Enums
{
    public enum VelicinaFirme
    {
        [Display(Name = "Mikro (1-5)")]
        Mikro = 1,
        [Display(Name = "Mala (5-20)")]
        Mala = 1,

        [Display(Name = "Srednja (20-50)")]
        Srednja = 2,

        [Display(Name = "Velika (50+)")]
        Velika = 3
    }
}
