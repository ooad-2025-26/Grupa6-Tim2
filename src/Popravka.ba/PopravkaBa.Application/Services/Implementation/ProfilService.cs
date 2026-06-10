using Microsoft.AspNetCore.Identity;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Domain.Models;

namespace PopravkaBa.Application.Services.Implementation
{
    public class ProfilService : IProfilService
    {
        private readonly IIzvrsilacUslugeRepository _izvrsilacUslugeRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilService(
            IIzvrsilacUslugeRepository izvrsilacUslugeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _izvrsilacUslugeRepository = izvrsilacUslugeRepository;
            _userManager = userManager;
        }


        // Detaljan prikaz profila za Detalji.cshtml
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
                Lokacija = izvrsilac.Mjesta?.FirstOrDefault()?.Mjesto?.Naziv,
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

            return dto;
        }

        // Dohvata samo polja za formu uređivanja — ne loada nepotrebne podatke
        public async Task<UrediProfilDto?> DajZaUredjivanjеAsync(string id)
        {
            var izvrsilac = await _izvrsilacUslugeRepository.DajProfilPoIdAsync(id);
            if (izvrsilac == null) return null;

            var dto = new UrediProfilDto
            {
                Id = izvrsilac.Id,
                Ime = izvrsilac.Ime,
                Prezime = izvrsilac.Prezime,
                Opis = izvrsilac.Opis,
                Adresa = izvrsilac.Adresa,
                MinCijenaUsluge = izvrsilac.MinCijenaUsluge,
                JeFirma = izvrsilac is Firma,
            };

            // Dodaj firma-specifična polja ako je firma
            if (izvrsilac is Firma firma)
            {
                dto.NazivFirme = firma.NazivFirme;
                dto.WebStranica = firma.WebStranica;
                dto.RadnoVrijeme = firma.RadnoVrijeme;
            }

            return dto;
        }

        // Snima izmjene u bazu — vraća true ako je uspješno, false ako korisnik nije pronađen
        public async Task<bool> UrediProfilAsync(UrediProfilDto dto)
        {
            var izvrsilac = await _izvrsilacUslugeRepository.DajProfilPoIdAsync(dto.Id);
            if (izvrsilac == null) return false;     

            izvrsilac.Ime = dto.Ime;
            izvrsilac.Prezime = dto.Prezime;
            izvrsilac.Opis = dto.Opis;
            izvrsilac.Adresa = dto.Adresa ?? izvrsilac.Adresa;
            izvrsilac.MinCijenaUsluge = dto.MinCijenaUsluge;

            if (izvrsilac is Firma firma)
            {
                firma.WebStranica = dto.WebStranica; 
                firma.RadnoVrijeme = dto.RadnoVrijeme;
            }

            // Koristi UserManager umjesto SaveChangesAsync direktno
            var result = await _userManager.UpdateAsync(izvrsilac);
            return result.Succeeded;
        }
    }
}
