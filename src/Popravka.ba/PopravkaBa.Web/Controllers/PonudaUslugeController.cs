using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.Services.Interface;
using PopravkaBa.Application.DTOs;

namespace PopravkaBa.Web.Controllers
{
    public class PonudaUslugeController : Controller
    {
        private readonly IPonudaUslugeService _ponudaUslugeService;
        private readonly IOglasUslugeService _oglasUslugeService;
        private readonly ILogger<PonudaUslugeController> _logger;

        public PonudaUslugeController(IPonudaUslugeService ponudaUslugeService, IOglasUslugeService oglasUslugeService,ILogger<PonudaUslugeController> logger)
        {
            _ponudaUslugeService = ponudaUslugeService;
            _oglasUslugeService = oglasUslugeService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int oglasId)
        {
            var ponude = await _oglasUslugeService.DajSvePonude(oglasId);
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
        public async Task<IActionResult> Apliciraj(KreirajPonudaUslugeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            // treba doraditi metodu

            return View();
        }

        //trenutno nema u dijagramu opcija uređivanja prijave pa nisam dodao

        public async Task<IActionResult> ObrisiPonudu(int ponudaId)
        {
            //ovdje ubaciti provjeru da prijava pripada korisniku
            //i da se otvori pop-up ekran ili nesto za potvrdu brisanja
            return View();
        }

        [HttpPost, ActionName("Brisanje")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObrisanaPonuda(int ponudaId)
        {
            //obrisi prijavu iz baze
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PrihvatiPonudu(int ponudaId)
        {
            //ovdje ubaciti provjeru da prijava pripada klijentu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrihvacenaPonuda(int ponudaId)
        {
            await _ponudaUslugeService.PrihvatiPonudu(ponudaId);
            // treba doraditi metodu

            return View();
        }

        public async Task<IActionResult> OdbijPonudu(int ponudaId)
        {
            //ovdje ubaciti provjeru da prijava pripada klijentu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OdbijenaPonuda(int ponudaId)
        {
            await _ponudaUslugeService.OdbijPonudu(ponudaId);
            // treba doraditi metodu

            return View();
        }
    }
}
