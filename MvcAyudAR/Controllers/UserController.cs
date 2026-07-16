using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcAyudAR.Application.DTOs.User;
using MvcAyudAR.Infrastructure;
using MvcAyudAR.Models;
using MvcAyudAR.Services.Commands.User;
using MvcAyudAR.Services.Interfaces.User;


namespace MvcAyudAR.Controllers;

public class UserController:Controller
{
    private readonly ICreateUserHandler _createHandler;
    private readonly ILoginUserHandler _loginHandler;
    public UserController(ICreateUserHandler createHandler, ILoginUserHandler loginHandler)
    {
        _createHandler = createHandler;
        _loginHandler = loginHandler;
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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDTO request)
    { 
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        await _loginHandler.LoginHandler(request);
        
        return RedirectToAction("Index", "Home");
    }
    
    


}