using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Models;

using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Models;

namespace PopravkaBa.Application.Services.Implementation
{
    public class ProfilService : IProfilService
    {
        private readonly IIzvrsilacUslugeRepository _izvrsilacUslugeRepository;

        public ProfilService(IIzvrsilacUslugeRepository izvrsilacUslugeRepository)
        {
            _izvrsilacUslugeRepository = izvrsilacUslugeRepository;
        }

        public async Task<ProfilIzvrsilacDto?> DajProfilAsync(string id)
        {
            var izvrsilac = await _izvrsilacUslugeRepository.DajProfilPoIdAsync(id);
            if (izvrsilac == null) return null;

            var dto = new ProfilIzvrsilacDto
            {
                Id = izvrsilac.Id,
                DisplayName = izvrsilac.DisplayName,
                Slika = izvrsilac.Slika,
                Opis = izvrsilac.Opis,
                Lokacija = null,
                ProsjecnaOcjena = izvrsilac.ProsjecnaOcjena,
                BrojRecenzija = izvrsilac.BrojRecenzija,
                BrojZavrsenihPoslova = izvrsilac.BrojZavrsenihPoslova,
                MinCijenaUsluge = izvrsilac.MinCijenaUsluge,
                JeMajstor = izvrsilac is Majstor,

                Kategorije = izvrsilac.Kategorije?
                    .Select(ik => ik.Kategorija?.Naziv ?? "")
                    .Where(n => !string.IsNullOrEmpty(n))
                    .ToList() ?? new(),

                SlikePortfolija = izvrsilac.SlikePortfolija?
                    .Select(s => new PortfolioSlikaDto { URL = s.URL, Opis = s.Opis })
                    .ToList() ?? new(),

                Recenzije = izvrsilac.Recenzije?
                    .OrderByDescending(r => r.DatumRecenzije)
                    .Take(5)
                    .Select(r => new RecenzijaProfilDto
                    {
                        KlijentIme = r.Klijent?.DisplayName ?? "Korisnik",
                        KlijentSlika = r.Klijent?.Slika,
                        Ocjena = r.Ocjena,
                        Komentar = r.Komentar,
                        DatumRecenzije = r.DatumRecenzije
                    })
                    .ToList() ?? new(),
            };

            if (izvrsilac is Firma firma)
            {
                dto.WebStranica = firma.WebStranica;
                dto.RadnoVrijeme = firma.RadnoVrijeme;
                dto.VelicinaFirme = firma.VelicinaFirme.ToString();
            }

            if (izvrsilac is Majstor majstor)
            {
                // Oglas majstora učitavamo iz ponuda
                dto.GodinaIskustva = null; // dodati u model ako zatreba
            }

            return dto;
        }
    }
}