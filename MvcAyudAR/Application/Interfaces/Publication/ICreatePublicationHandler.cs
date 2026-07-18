using MvcAyudAR.Application.DTOs.Publication;
using MvcAyudAR.Models;

namespace MvcAyudAR.Services.DTOs;

public interface ICreatePublicationHandler
{
    Task<PublicationResponseDTO> Handle(PublicationRequestDTO request);
}