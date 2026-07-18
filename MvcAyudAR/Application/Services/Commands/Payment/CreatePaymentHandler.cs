using MvcAyudAR.Application.Interfaces.Payments;
using MvcAyudAR.Models.Exceptions;
using MvcAyudAR.Services.DTOs;
using MvcAyudAR.Services.DTOs.Payment;
using MvcAyudAR.Services.Interfaces.User;

namespace MvcAyudAR.Application.Services.Commands.Payment;

public class CreatePaymentHandler:ICreatePaymentHandler
{
    private readonly IPaymentRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IPublicationRepository _publicationRepository;
    public CreatePaymentHandler(IPaymentRepository repository, IUserRepository userRepository, IPublicationRepository publicationRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _publicationRepository = publicationRepository;
    }

    public async Task Handle(PaymentRequestDTO request)
    {
        if (request == null)
        {
            throw new ExceptionBadRequest("Ingrese parametros válidos");
        }

        var user = await _userRepository.GetUserByIdAsync(request.UserId) ?? throw new ExceptionNotFound("Usuario no encontrado");
        var publication = await _publicationRepository.GetPublicationByIdAsync(request.PublicationId) ?? throw new ExceptionNotFound("Publicación no encontrada");

        var payment = new Domain.Entities.Payment
        {
            PublicationId = request.PublicationId,
            UserId = request.UserId,
            TotalAmount = request.TotalAmount,
        };
        await _repository.InsertPaymentAsync(payment);
    }
}

