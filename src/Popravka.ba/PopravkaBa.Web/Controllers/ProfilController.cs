using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;
using System.Security.Claims;

namespace PopravkaBa.Web.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {
        private readonly IProfilService _profilService;

        public ProfilController(IProfilService profilService)
        {
            _profilService = profilService;
        }

        [HttpGet]
        public async Task<IActionResult> Detalji(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var profil = await _profilService.DajProfilAsync(id);
            if (profil == null)
                return NotFound();


            // da li je trenutni user = id profila koji je otvoren
            ViewBag.TrenutniKorisnikId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(profil);
        }

        
        // samo vlasnik profila može pristupiti
        [HttpGet]
        public async Task<IActionResult> UrediProfil(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            // Provjeri da li prijavljeni korisnik pokušava urediti svoj profil
            var trenutniKorisnikId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (trenutniKorisnikId != id)
                return Forbid();

            var dto = await _profilService.DajZaUredjivanjеAsync(id);
            if (dto == null)
                return NotFound();

            return View(dto);
        }

        // samo vlasnik profila može snimiti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediProfil(UrediProfilDto dto)
        {
            var trenutniKorisnikId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Ovo sprječava da neko pošalje formu sa tuđim ID-em;
            if (trenutniKorisnikId != dto.Id)
                return Forbid(); 

            if (!ModelState.IsValid)
            { 
                return View(dto);
            }

            var uspjeh = await _profilService.UrediProfilAsync(dto);
            if (!uspjeh)
                return NotFound();

            TempData["UspjehPoruka"] = "Profil je uspješno ažuriran.";
            return RedirectToAction(nameof(Detalji), new { id = dto.Id });
        }
    }
}