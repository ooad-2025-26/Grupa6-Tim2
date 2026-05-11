using PopravkaBa.Application.DTOs;
using PopravkaBa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopravkaBa.Application.Services.Interface
{
    public interface IOglasMajstoraService
    {
        Task<IEnumerable<OglasMajstora>> DajSveOglase();
        Task<OglasMajstora?> DajOglasPoId(int id);
        Task ObjaviOglas(ObjaviOglasMajstoraDto dto);
        Task UrediOglas(UrediOglasMajstoraDto dto);
        Task ObrisiOglas(int id);
        Task<IEnumerable<OglasMajstora>> PronadjiOglase(string pretraga);
    }

    public interface IOglasRadnoMjestoService
    {
    }

    public interface IOglasUslugeService
    {
    }
}
   