using MvcAyudAR.Models;

namespace MvcAyudAR.Services.DTOs;

public interface IPublicationRepository
{
    Task<Domain.Entities.Publication> InsertPublicationAsync(Domain.Entities.Publication publication, CancellationToken ct = default);
}