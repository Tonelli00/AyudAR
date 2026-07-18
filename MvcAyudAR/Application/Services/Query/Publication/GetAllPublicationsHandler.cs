using MvcAyudAR.Application.DTOs.Publication;
using MvcAyudAR.Application.Interfaces.Payments;
using MvcAyudAR.Services.DTOs;

namespace MvcAyudAR.Application.Services.Query.Publication;

public class GetAllPublicationsHandler:IGetAllPublicationsHandler
{
    private readonly IPublicationRepository _repository;
    private readonly IPaymentRepository _paymentRepository;
    public GetAllPublicationsHandler(IPublicationRepository repository, IPaymentRepository paymentRepository)
    {
        _repository = repository;
        _paymentRepository = paymentRepository;
    }

    public async Task<List<PublicationResponseDTO>> Handle()
    {
        var publications = await _repository.GetAllAsync();
        var result = new List<PublicationResponseDTO>();

        foreach (var pub in publications)
        {
            result.Add(new PublicationResponseDTO
            {
                Title   = pub.Title,
                Description = pub.Description,
                CurrentlyTotal = await _paymentRepository.GetCurrentlyAmount(pub.Id),
                TTR = pub.TTR,
                
            });
        }

        return result;
    }
}