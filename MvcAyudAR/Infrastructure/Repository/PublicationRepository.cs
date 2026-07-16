using MvcAyudAR.Domain.Entities;
using MvcAyudAR.Infrastructure.Persistence;
using MvcAyudAR.Services.DTOs;

namespace MvcAyudAR.Infrastructure.Repository;

public class PublicationRepository : IPublicationRepository
{
    private readonly AppDbContext _context;

    public PublicationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Publication> InsertPublicationAsync(Publication publication, CancellationToken ct = default)
    {
        await _context.Publications.AddAsync(publication, ct);
        await _context.SaveChangesAsync(ct);
        return publication;
    }
}