using MvcAyudAR.Services.DTOs.Payment;

namespace MvcAyudAR.Application.Interfaces.Payments;

public interface ICreatePaymentHandler
{
    Task Handle(PaymentRequestDTO request);
}