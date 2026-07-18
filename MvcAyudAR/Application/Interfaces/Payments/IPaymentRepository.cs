using MvcAyudAR.Domain.Entities;

namespace MvcAyudAR.Application.Interfaces.Payments;

public interface IPaymentRepository
{
    Task<double> GetCurrentlyAmount(Guid PublicationId, CancellationToken ct = default);
    Task<Payment> InsertPaymentAsync(Payment payment, CancellationToken ct = default);
}