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
        Task<int> ObjaviOglas(ObjaviOglasMajstoraDto dto, string vlasnikId);
        Task UrediOglas(UrediOglasMajstoraDto dto);
        Task ObrisiOglas(int id);
        Task<IEnumerable<OglasMajstora>> PronadjiOglase(string pretraga);
    }

    public interface IOglasRadnoMjestoService
    {
        Task<IEnumerable<OglasRadnoMjesto>> DajSveOglase();
        Task<OglasRadnoMjesto?> DajOglasPoId(int id);
        Task<int> ObjaviOglas(ObjaviOglasRadnoMjestoDto dto,string vlasnikId);
        Task UrediOglas(UrediOglasRadnoMjestoDto dto);
        Task ObrisiOglas(int id);
        Task<IEnumerable<OglasRadnoMjesto>> PronadjiOglase(string pretraga);
    }

    public interface IOglasUslugeService
    {
        Task<IEnumerable<OglasUsluge>> DajSveOglase();
        Task<OglasUsluge?> DajOglasPoId(int id);
        Task<int> ObjaviOglas(ObjaviOglasUslugeDto dto, string vlasnikId);
        Task UrediOglas(UrediOglasUslugeDto dto);
        Task ObrisiOglas(int id);
        Task<IEnumerable<OglasUsluge>> PronadjiOglase(string pretraga);
    }
}
   