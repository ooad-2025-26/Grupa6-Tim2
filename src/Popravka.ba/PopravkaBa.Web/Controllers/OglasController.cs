using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Domain.Interfaces;

namespace PopravkaBa.Web.Controllers
{
    public class OglasMajstoraController : Controller
    {
        private readonly IOglasMajstoraService _oglasMajstoraService;
        private readonly ILogger<OglasMajstoraController> _logger;

        public OglasMajstoraController(IOglasMajstoraService oglasMajstoraService, ILogger<OglasMajstoraController> logger)
        {
            _oglasMajstoraService = oglasMajstoraService;
            _logger = logger;
        }


        public async Task<IActionResult> Index(string? pretraga)
        {
            var oglasi = string.IsNullOrWhiteSpace(pretraga)
                ? await _oglasMajstoraService.DajSveOglase()
                : await _oglasMajstoraService.PronadjiOglase(pretraga);
            ViewBag.Search = pretraga;
            return View(oglasi);
        }

        public async Task<IActionResult> Detalji(int id)
        {
            var oglas = _oglasMajstoraService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        public IActionResult KreirajOglas() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KreirajOglas(KreirajOglasMajstoraDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasMajstoraService.KreirajOglas(dto);
                TempData["Success"] = "Oglas je uspješno kreiran";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(dto);
            }
        }

        public async Task<IActionResult> UrediOglas(int id)
        {
            var oglas = await _oglasMajstoraService.DajOglasPoId(id);
            if (oglas is null) return NotFound();

            var dto = new UrediOglasMajstoraDto
            { };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediOglas(int id, UrediOglasMajstoraDto dto)
        {
            if (id != dto.id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasMajstoraService.UrediOglas(dto);
                TempData["Success"] = "Oglas je uspješno uređen";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

        public async Task<IActionResult> ObrisiOglas(int id)
        {
            var oglas = await _oglasMajstoraService.DajKnjiguPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        // POST /Books/Delete/5
        [HttpPost, ActionName("Brisanje oglasa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdaBrisanjaOglasa(int id)
        {
            try
            {
                await _oglasMajstoraService.ObrisiOglas(id);
                TempData["Success"] = "Oglas je obrisan.";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }

    public class OglasRadnoMjestoController : Controller
    {
        private readonly IOglasRadnoMjestoService _oglasRadnoMjestoService;
        private readonly ILogger<OglasRadnoMjestoController> _logger;

        public OglasRadnoMjestoController(IOglasRadnoMjestoService oglasRadnoMjestoService, ILogger<OglasRadnoMjestoController> logger)
        {
            _oglasRadnoMjestoService = oglasRadnoMjestoService;
            _logger = logger;
        }


        public async Task<IActionResult> Index(string? pretraga)
        {
            var oglasi = string.IsNullOrWhiteSpace(pretraga)
                ? await _oglasRadnoMjestoService.DajSveOglase()
                : await _oglasRadnoMjestoService.PronadjiOglase(pretraga);
            ViewBag.Search = pretraga;
            return View(oglasi);
        }

        public async Task<IActionResult> Detalji(int id)
        {
            var oglas = _oglasRadnoMjestoService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        public IActionResult KreirajOglas() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KreirajOglas(KreirajOglasRadnoMjestoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasRadnoMjestoService.KreirajOglas(dto);
                TempData["Success"] = "Oglas je uspješno kreiran";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(dto);
            }
        }

        public async Task<IActionResult> UrediOglas(int id)
        {
            var oglas = await _oglasRadnoMjestoService.DajOglasPoId(id);
            if (oglas is null) return NotFound();

            var dto = new UrediOglasRadnoMjestoDto
            { };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediOglas(int id, UrediOglasRadnoMjestoDto dto)
        {
            if (id != dto.id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasRadnoMjestoService.UrediOglas(dto);
                TempData["Success"] = "Oglas je uspješno uređen";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

        public async Task<IActionResult> ObrisiOglas(int id)
        {
            var oglas = await _oglasRadnoMjestoService.DajKnjiguPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        // POST /Books/Delete/5
        [HttpPost, ActionName("Brisanje oglasa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdaBrisanjaOglasa(int id)
        {
            try
            {
                await _oglasRadnoMjestoService.ObrisiOglas(id);
                TempData["Success"] = "Oglas je obrisan.";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
