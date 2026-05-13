using Microsoft.EntityFrameworkCore;
using Popravka.ba.Data;
using PopravkaBa.Domain.Models;
using PopravkaBa.Domain.Interfaces;

namespace PopravkaBa.Infrastructure.Repositories
{
    public class OglasMajstoraRepository : IOglasMajstoraRepository
    {
        private readonly ApplicationDbContext _context;

        public OglasMajstoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OglasMajstora>> DajSveAsync()
            => await _context.OglasiMajstora
                .Include(o => o.Mjesto)
                .Include(o => o.VlasnikOglasa)
                .ToListAsync();

        public async Task<OglasMajstora?> DajPoIdAsync(int id)
            => await _context.OglasiMajstora
                .Include(o => o.Mjesto)
                .Include(o => o.VlasnikOglasa)
                .FirstOrDefaultAsync(o => o.OglasID == id);

        public async Task DodajAsync(OglasMajstora oglas)
        {
            oglas.DatumObjave = DateTime.Now;
            await _context.OglasiMajstora.AddAsync(oglas);
            await _context.SaveChangesAsync();
        }

        public async Task UrediAsync(OglasMajstora oglas)
        {
            _context.OglasiMajstora.Update(oglas);
            await _context.SaveChangesAsync();
        }

        public async Task ObrisiAsync(int id)
        {
            var oglas = await _context.OglasiMajstora.FindAsync(id);
            if (oglas is not null)
            {
                _context.OglasiMajstora.Remove(oglas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OglasMajstora>> IzvrsiPretraguTekstaAsync(string pretraga)
            => await _context.OglasiMajstora
                .Include(o => o.Mjesto)
                .Include(o => o.VlasnikOglasa)
                .Where(o => o.Naslov.Contains(pretraga) || o.Opis.Contains(pretraga))
                .ToListAsync();
    }

    public class OglasUslugeRepository : IOglasUslugeRepository
    {

        private readonly ApplicationDbContext _context;
        public OglasUslugeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OglasUsluge?> DajPoIdAsync(int id) => 
            await _context.OglasiUsluga.
            Include(o => o.VlasnikOglasa).
            Include(o => o.Mjesto).
            FirstOrDefaultAsync(o => o.OglasID == id);

        public async Task<IEnumerable<OglasUsluge>> DajSveAsync() => 
            await _context.OglasiUsluga.
            Include(o => o.VlasnikOglasa).
            Include(o => o.Mjesto).
            ToListAsync();



        public async Task DodajAsync(OglasUsluge oglas)
        {
            oglas.DatumObjave = DateTime.Now;
            await _context.OglasiUsluga.AddAsync(oglas);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<OglasUsluge>> IzvrsiPretraguTekstaAsync(string pretraga)
            => await _context.OglasiUsluga
                .Include(o => o.Mjesto)
                .Include(o => o.VlasnikOglasa)
                .Where(o => o.Naslov.Contains(pretraga) || o.Opis.Contains(pretraga))
                .ToListAsync();

        public async Task ObrisiAsync(int id)
        {
            var oglas = await _context.OglasiUsluga.FindAsync(id);
            if (oglas is not null)
            {
                _context.OglasiUsluga.Remove(oglas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UrediAsync(OglasUsluge oglas)
        {
            _context.OglasiUsluga.Update(oglas);
            await _context.SaveChangesAsync();
        }
    }

    // TODO Implementirati OglasRadnoMjestoRepository REPOSITORIES
    // TODO 1HIGHPRIORITY: Provjeriti da li su svi navigation propertyevi pravilno povezani na queryeve
    public class OglasRadnoMjestoRepository : IOglasRadnoMjestoRepository
    {
        private readonly ApplicationDbContext _context;

        public async Task<OglasRadnoMjesto?> DajPoIdAsync(int id) => 
            await  _context.OglasiRadnogMjesta
            .Include(orm => orm.VozackeDozvole)
            .Include(orm => orm.Uvjeti)
            .Include(orm => orm.VlasnikOglasa)
            .Include(orm => orm.Prijave)
            .Include(orm => orm.Mjesto)
            .Include(orm => orm.Kategorije)
            .Include(orm => orm.Notifikacije)
            .FirstOrDefaultAsync(orm => orm.OglasID == id);


        public async Task<IEnumerable<OglasRadnoMjesto>> DajSveAsync() =>
        await _context.OglasiRadnogMjesta
            .Include(orm => orm.VozackeDozvole)
            .Include(orm => orm.Uvjeti)
            .Include(orm => orm.VlasnikOglasa)
            .Include(orm => orm.Prijave)
            .Include(orm => orm.Mjesto)
            .Include(orm => orm.Kategorije)
            .Include(orm => orm.Notifikacije)
            .ToListAsync();

        public Task DodajAsync(OglasRadnoMjesto oglas)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OglasRadnoMjesto>> IzvrsiPretraguTekstaAsync(string pretraga)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UrediAsync(OglasRadnoMjesto oglas)
        {
            throw new NotImplementedException();
        }
    }
}
