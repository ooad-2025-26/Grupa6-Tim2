using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;

namespace PopravkaBa.Web.Controllers
{
    [Authorize(Roles = "Administrator, Majstor")]
    public class OglasMajstoraController : Controller
    {
        private readonly IOglasMajstoraService _oglasMajstoraService;
        private readonly ILogger<OglasMajstoraController> _logger;

        public OglasMajstoraController(IOglasMajstoraService oglasMajstoraService, ILogger<OglasMajstoraController> logger)
        {
            _oglasMajstoraService = oglasMajstoraService;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string? pretraga)
        {
            var oglasi = string.IsNullOrWhiteSpace(pretraga)
                ? await _oglasMajstoraService.DajSveOglase()
                : await _oglasMajstoraService.PronadjiOglase(pretraga);
            ViewBag.Search = pretraga;
            return View(oglasi);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detalji(int id)
        {
            var oglas = _oglasMajstoraService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        public IActionResult ObjaviOglas() => View();

        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObjaviOglas(ObjaviOglasMajstoraDto dto)
        {
            if (!ModelState.IsValid) return View(dto);


            try
            {
                await _oglasMajstoraService.ObjaviOglas(dto);
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
            var oglas = await _oglasMajstoraService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        
        [HttpPost, ActionName("ObrisiOglas")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdaBrisanjaOglasa(int id)
        {
            try
            {
                await _oglasMajstoraService.ObrisiOglas(id);
                TempData["Success"] = "Oglas je uspješno obrisan.";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }

    [Authorize(Roles = "Administrator, Firma")]
    public class OglasRadnoMjestoController : Controller
    {
        private readonly IOglasRadnoMjestoService _oglasRadnoMjestoService;
        private readonly ILogger<OglasRadnoMjestoController> _logger;

        public OglasRadnoMjestoController(IOglasRadnoMjestoService oglasRadnoMjestoService, ILogger<OglasRadnoMjestoController> logger)
        {
            _oglasRadnoMjestoService = oglasRadnoMjestoService;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string? pretraga)
        {
            var oglasi = string.IsNullOrWhiteSpace(pretraga)
                ? await _oglasRadnoMjestoService.DajSveOglase()
                : await _oglasRadnoMjestoService.PronadjiOglase(pretraga);
            ViewBag.Search = pretraga;
            return View(oglasi);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalji(int id)
        {
            var oglas = _oglasRadnoMjestoService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        public IActionResult ObjaviOglas() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObjaviOglas(ObjaviOglasRadnoMjestoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasRadnoMjestoService.ObjaviOglas(dto);
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
            var oglas = await _oglasRadnoMjestoService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        
        [HttpPost, ActionName("ObrisiOglas")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdaBrisanjaOglasa(int id)
        {
            try
            {
                await _oglasRadnoMjestoService.ObrisiOglas(id);
                TempData["Success"] = "Oglas je uspješno obrisan.";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }

    [Authorize(Roles = "Administrator, Klijent")]
    public class OglasUslugeController : Controller
    {
        private readonly IOglasUslugeService _oglasUslugeService;
        private readonly ILogger<OglasUslugeController> _logger;

        public OglasUslugeController(IOglasUslugeService oglasUslugeService, ILogger<OglasUslugeController> logger)
        {
            _oglasUslugeService = oglasUslugeService;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string? pretraga)
        {
            var oglasi = string.IsNullOrWhiteSpace(pretraga)
                ? await _oglasUslugeService.DajSveOglase()
                : await _oglasUslugeService.PronadjiOglase(pretraga);
            ViewBag.Search = pretraga;
            return View(oglasi);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalji(int id)
        {
            var oglas = _oglasUslugeService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }

        public IActionResult ObjaviOglas() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ObjaviOglas(ObjaviOglasUslugeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasUslugeService.ObjaviOglas(dto);
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
            var oglas = await _oglasUslugeService.DajOglasPoId(id);
            if (oglas is null) return NotFound();

            var dto = new UrediOglasUslugeDto
            { };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrediOglas(int id, UrediOglasUslugeDto dto)
        {
            if (id != dto.id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _oglasUslugeService.UrediOglas(dto);
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
            var oglas = await _oglasUslugeService.DajOglasPoId(id);
            if (oglas is null) return NotFound();
            return View(oglas);
        }


        [HttpPost, ActionName("ObrisiOglas")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdaBrisanjaOglasa(int id)
        {
            try
            {
                await _oglasUslugeService.ObrisiOglas(id);
                TempData["Success"] = "Oglas je uspješno obrisan.";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
