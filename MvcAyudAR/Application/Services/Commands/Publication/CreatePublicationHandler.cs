using MvcAyudAR.Application.DTOs.Publication;
using MvcAyudAR.Models.Exceptions;
using MvcAyudAR.Services.DTOs;


namespace MvcAyudAR.Application.Services.Commands.Publication;

public class CreatePublicationHandler:ICreatePublicationHandler
{
    private IPublicationRepository _repository;

    public CreatePublicationHandler(IPublicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<PublicationResponseDTO> Handle(PublicationRequestDTO request)
    {
        if (String.IsNullOrWhiteSpace(request.Title))
        {
            throw new ExceptionBadRequest("Ingrese un titulo válido");
        }

        if (String.IsNullOrWhiteSpace(request.Description))
        {
            throw new ExceptionBadRequest("Ingrese una descripción válida");
        }

        if (request.TTR < 0)
        {
            throw new ExceptionBadRequest("Ingrese un monto válido");
        }

        var publication = new Domain.Entities.Publication
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Photos = request.Photos ?? new List<string>(),
            TTR = request.TTR
        };

        var publicationCreated = await _repository.InsertPublicationAsync(publication);

        return new PublicationResponseDTO
        {
         Id = publicationCreated.Id,
         Description = publicationCreated.Description,
         Title = publicationCreated.Title,
         TTR = publicationCreated.TTR
        };

    }
}