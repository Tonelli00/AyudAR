using Microsoft.EntityFrameworkCore;
using MvcAyudAR.Application.Interfaces.Payments;
using MvcAyudAR.Infrastructure.Persistence;

namespace MvcAyudAR.Infrastructure.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<double> GetCurrentlyAmount(Guid PublicationId, CancellationToken ct = default)
    {
        var total = await _context.Payments.Where(p => p.PublicationId == PublicationId)
            .SumAsync(p => p.TotalAmount, ct);
        return total;
    }
}