using Microsoft.AspNetCore.Mvc;
using MvcAyudAR.Application.DTOs.Publication;
using MvcAyudAR.Services.DTOs;

namespace MvcAyudAR.Controllers;

public class PublicationController : Controller
{
    private readonly ICreatePublicationHandler _createHandler;

    public PublicationController(ICreatePublicationHandler createHandler)
    {
        _createHandler = createHandler;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PublicationRequestDTO request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        await _createHandler.Handle(request);
        return RedirectToAction("Index", "Home");
    }
}