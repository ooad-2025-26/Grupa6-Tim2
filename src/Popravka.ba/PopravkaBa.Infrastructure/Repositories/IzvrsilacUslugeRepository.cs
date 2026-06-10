using Microsoft.EntityFrameworkCore;
using Popravka.ba.Data;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Models;
using PopravkaBa.Domain.Specifications.Interface;
using PopravkaBa.Infrastructure.Wrappers;

namespace PopravkaBa.Infrastructure.Repositories
{
    public class IzvrsilacUslugeRepository : IIzvrsilacUslugeRepository
    {
        private readonly ApplicationDbContext _context;

        public IzvrsilacUslugeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dohvata profil sa svim navigation propertijima za prikaz
        // VAŽNO: bez AsNoTracking() kada ćemo snimati izmjene
        public async Task<IzvrsilacUsluge?> DajProfilPoIdAsync(string id)
        {
            return await _context.ApplicationUsers
                .OfType<IzvrsilacUsluge>() 
                .Include(i => i.Kategorije).ThenInclude(k => k.Kategorija)
                .Include(i => i.SlikePortfolija)
                .Include(i => i.Recenzije).ThenInclude(r => r.Klijent)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Snima sve izmjene koje su napravljene na tracked entitetima
        public async Task SacuvajAsync()
        {
            var rows = await _context.SaveChangesAsync();
        }

        public async Task<StraniceniRezultat<IzvrsilacUsluge>> PronadjiAsync(
            ISpecification<IzvrsilacUsluge> spec, int stranica, int stavkiPoStranici)
        {
            var query = _context.ApplicationUsers
                .OfType<IzvrsilacUsluge>()
                .AsSplitQuery()
                .Include(m => m.Mjesta)
                    .ThenInclude(km => km.Mjesto)
                .Include(m => m.Kategorije)
                    .ThenInclude(ik => ik.Kategorija)
                .Where(spec.ToExpression())
                .AsNoTracking();

            var ukupno = await query.CountAsync();

            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);
            else if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            var stavke = await query
                .Skip((stranica - 1) * stavkiPoStranici)
                .Take(stavkiPoStranici)
                .ToListAsync();

            return new StraniceniRezultat<IzvrsilacUsluge> { Stavke = stavke, Ukupno = ukupno };
        }

        public Task<IEnumerable<IzvrsilacUsluge>> DajSveAsync()
            => throw new NotImplementedException();

        public Task<IzvrsilacUsluge?> DajPoIdAsync(int id)
            => throw new NotImplementedException();

        public Task DodajAsync(IzvrsilacUsluge oglas)
            => throw new NotImplementedException();

        public Task UrediAsync(IzvrsilacUsluge oglas)
            => throw new NotImplementedException();

        public Task ObrisiAsync(int id)
            => throw new NotImplementedException();

        public Task<IEnumerable<IzvrsilacUsluge>> IzvrsiPretraguTekstaAsync(string pretraga)
            => throw new NotImplementedException();
    }
}