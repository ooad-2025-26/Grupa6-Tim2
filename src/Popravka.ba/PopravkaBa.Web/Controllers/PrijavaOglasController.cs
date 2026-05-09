using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Domain.Interfaces;
using PopravkaBa.Application.DTOs;

namespace PopravkaBa.Web.Controllers
{
    public class PrijavaOglasController : Controller
    {
        private readonly IPrijavaOglasService _prijavaOglasService;
        private readonly IOglasRadnoMjestoService _oglasRadnoMjestoService;
        private readonly ILogger<PrijavaOglasController> _logger;

        public PrijavaOglasController(IPrijavaOglasService prijavaOglasService, IOglasRadnoMjestoService oglasRadnoMjestoService, ILogger<PrijavaOglasController> logger)
        {
            _prijavaOglasService = prijavaOglasService;
            _oglasRadnoMjestoService = oglasRadnoMjestoService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int oglasId)
        {
            var ponude = await _oglasRadnoMjestoService.DajSvePonude(oglasId);
            ViewBag.Search = oglasId;
            return View(ponude);
        }

        public async Task<IActionResult> Apliciraj(int oglasId)
        {
            ViewBag.OglasId = oglasId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apliciraj(KreirajPrijavaOglasDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            // treba doraditi metodu

            return View();
        }

        //trenutno nema u dijagramu opcija uređivanja prijave pa nisam dodao

        public async Task<IActionResult> ObrisiPrijavu(int prijavaId)
        {
            //ovdje ubaciti provjeru da prijava pripada korisniku
            //i da se otvori pop-up ekran ili nesto za potvrdu brisanja
            return View();
        }

        [HttpPost, ActionName("Brisanje")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObrisanaPrijava(int prijavaId)
        {
            //obrisi prijavu iz baze
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PrihvatiPonudu(int prijavaId)
        {
            //ovdje ubaciti provjeru da prijava pripada klijentu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrihvacenaPonuda(int prijavaId)
        {
            await _prijavaOglasService.PrihvatiPonudu(prijavaId);
            // treba doraditi metodu

            return View();
        }

        public async Task<IActionResult> OdbijPrijavu(int prijavaId)
        {
            //ovdje ubaciti provjeru da prijava pripada klijentu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OdbijenaPrijava(int prijavaId)
        {
            await _prijavaOglasService.OdbijPrijavu(prijavaId);
            // treba doraditi metodu

            return View();
        }
    }
}
