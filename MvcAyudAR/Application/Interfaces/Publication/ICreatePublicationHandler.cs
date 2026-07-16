using MvcAyudAR.Application.DTOs.Publication;
using MvcAyudAR.Models;

namespace MvcAyudAR.Services.DTOs;

public interface ICreatePublicationHandler
{
    Task<Domain.Entities.Publication> Handle(PublicationRequestDTO request);
}