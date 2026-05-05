using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Domain.Models
{

    public class EmailVerifikacijaFirme : VerifikacijaFirme
    {
        public string AdminEmail { get; set; }

        public override void ObradiVerifikaciju(bool odobri)
        {
            throw new NotImplementedException();
        }

        public override void PodnesiVerifikaciju()
        {
            throw new NotImplementedException();
        }
    }
}
