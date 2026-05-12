using PopravkaBa.Domain.Models;

namespace PopravkaBa.Domain.Interfaces.Repositories
{

    // TODO implementirati.
    public interface IRecenzijaRepository
    {
        Task<IEnumerable<Recenzija>> DajSveAsync();
        Task<IEnumerable<Recenzija>> DajRecenzijeIzvrsiocaAsync(string izvrsilacId);
        Task<IEnumerable<Recenzija>> DajRecenzijeKlijentaAsync(string klijentId);
        Task<Recenzija?> DajPoIdAsync(int id);
        Task DodajAsync(Recenzija recenzija);
        Task SacuvajAsync(Recenzija recenzija);
        Task ObrisiAsync(int id);
    }
}