using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.DTOs;
using PopravkaBa.Application.Services.Interface;

namespace PopravkaBa.Web.Controllers
{
    public class RecenzijaController : Controller
    {
        private readonly IRecenzijaService _recenzijaService;
        private readonly ILogger<RecenzijaController> _logger;

        public RecenzijaController(IRecenzijaService recenzijaService, ILogger<RecenzijaController> logger)
        {
            _recenzijaService = recenzijaService;
            _logger = logger;
        }

        //možda bude potrebno povezati recenziju s oglasom kako bi se utvrdilo
        //da li je oglas aktivan ili tako nešto (lupam ali morat će imati povezanosti)
        //ako ništa iz oglasa da ima neki status
    
        public async Task<IActionResult> Index(int izvrsilacId)
        {
            var recenzije = 0; // = await _recenzijaService.DajRecenzijePoId(izvrsilacId);
            ViewBag.Izvrsilac = izvrsilacId;
            return View(recenzije);
        }

        public async Task<IActionResult> Objavi(/*vidjet cemo sta*/) 
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Objavi(KreirajRecenzijaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            // treba doraditi metodu

            return View();
        }

        public async Task<IActionResult> Prijavi(int recenzijaId)
        {
            ViewBag.RecenzijaId = recenzijaId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Prijavi(int recenzijaId, PrijaviRecenzijaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            // treba doraditi metodu

            return View();
        }
    }    
}
