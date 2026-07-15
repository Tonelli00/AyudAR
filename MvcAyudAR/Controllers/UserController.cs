using Microsoft.AspNetCore.Mvc;
using MvcAyudAR.Data;

namespace MvcAyudAR.Controllers;

public class UserController:Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    


}