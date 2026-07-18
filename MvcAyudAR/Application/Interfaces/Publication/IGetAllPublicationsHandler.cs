using MvcAyudAR.Application.DTOs.Publication;

namespace MvcAyudAR.Services.DTOs;

public interface IGetAllPublicationsHandler
{
    Task<List<PublicationResponseDTO>> Handle();
}