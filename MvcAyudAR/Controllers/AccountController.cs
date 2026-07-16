using Microsoft.AspNetCore.Mvc;

namespace MvcAyudAR.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}