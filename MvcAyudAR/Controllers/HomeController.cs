using Microsoft.AspNetCore.Mvc;

namespace MvcAyudAR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}