using PopravkaBa.Application.DTOs;
using PopravkaBa.Domain.Models;

namespace PopravkaBa.Application.Services.Interface
{
    // TODO Implementirati RecenzijaService SERVICES
    public interface IRecenzijaService
    {
        Task<IEnumerable<Recenzija>> DajSveRecenzije();
        Task<IEnumerable<Recenzija>> DajRecenzijePoId(string izvrsilacId);
        Task<IEnumerable<Recenzija>> DajRecenzijeKlijenta(string klijentId);
        Task<Recenzija?> DajRecenzijuPoId(int id);
        Task ObjaviRecenziju(KreirajRecenzijuDto dto, string klijentId);
        Task PrijaviRecenziju(PrijaviRecenzijuDto dto);
    }
}