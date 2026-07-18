using Microsoft.AspNetCore.Mvc;
using MvcAyudAR.Application.Interfaces.Payments;
using MvcAyudAR.Services.DTOs.Payment;

namespace MvcAyudAR.Controllers;

public class PaymentController : Controller
{
    private readonly ICreatePaymentHandler _createPaymentHandler;

    public PaymentController(ICreatePaymentHandler createPaymentHandler)
    {
        _createPaymentHandler = createPaymentHandler;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PaymentRequestDTO request)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _createPaymentHandler.Handle(request);
        return RedirectToAction("Index", "Home");
    }
}