using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Application.Services
{
    public class OglasMajstora : IOglasMajstoraService
    {
        public Task<OglasMajstora?> DajOglasPoId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OglasMajstora>> DajSveOglase()
        {
            throw new NotImplementedException();
        }

        public Task ObjaviOglas(ObjaviOglasMajstoraDto dto)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiOglas(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OglasMajstora>> PronadjiOglase(string pretraga)
        {
            throw new NotImplementedException();
        }

        public Task UrediOglas(UrediOglasMajstoraDto dto)
        {
            throw new NotImplementedException();
        }
    }

    public class OglasRadnoMjestoService : IOglasRadnoMjestoService
    {

    }
    
    public class OglasUslugeService : IOglasUslugeService
    {
    }
}
