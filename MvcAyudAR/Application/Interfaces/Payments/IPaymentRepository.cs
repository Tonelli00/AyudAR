namespace MvcAyudAR.Application.Interfaces.Payments;

public interface IPaymentRepository
{
    Task<double> GetCurrentlyAmount(Guid PublicationId, CancellationToken ct = default);
}