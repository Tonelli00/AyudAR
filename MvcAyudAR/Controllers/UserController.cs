using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcAyudAR.Data;
using MvcAyudAR.Models;
using MvcAyudAR.Models.DTOs.User;
using MvcAyudAR.Services.Commands.User;
using MvcAyudAR.Services.Interfaces.User;


namespace MvcAyudAR.Controllers;

public class UserController:Controller
{
    private readonly ICreateUserHandler _createHandler;
    public UserController(ICreateUserHandler createHandler)
    {
        _createHandler = createHandler;
    }
    
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration( UserRequestDTO request)
    { 
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        await _createHandler.CreateUser(request);

        return RedirectToAction("Index", "Home");
    }

    


}