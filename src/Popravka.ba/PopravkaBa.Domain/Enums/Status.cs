using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Domain.Enums
{
    public enum Status
    {
        NaCekanju,
        Prihvaceno,
        Odbijeno,
        Neaktivan, // TODO Tokeni i verifikacija
        Isporuceno
    }
}
