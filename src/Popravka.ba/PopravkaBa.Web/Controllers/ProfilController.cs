using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.Services.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopravkaBa.Application.Services.Interface;

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

            return View(profil);
        }
    }
}