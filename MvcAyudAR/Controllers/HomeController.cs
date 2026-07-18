using Microsoft.AspNetCore.Mvc;
using MvcAyudAR.Services.DTOs;

namespace MvcAyudAR.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAllPublicationsHandler _getPublications;

        public HomeController(IGetAllPublicationsHandler getPublications)
        {
            _getPublications = getPublications;
        }

        public async Task<IActionResult> Index()
        {
            var publications = await _getPublications.Handle();
            return View(publications);
        }
    }
}