using MvcAyudAR.Models.DTOs.User;
using MvcAyudAR.Models.Exceptions;
using MvcAyudAR.Services.Interfaces.User;

namespace MvcAyudAR.Services.Commands.User;

public class CreateUserHandler:ICreateUserHandler
{
    private readonly IUserRepository _repository;

    public CreateUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Models.User> CreateUser(UserRequestDTO request)
    {
        if (request == null)
        {
            throw new ExceptionNotFound("Ingrese información válida");
        }

        if (String.IsNullOrEmpty(request.Dni))
        {
            throw new ExceptionBadRequest("Ingrese un dni válido");
        }
        if (String.IsNullOrEmpty(request.FullName))
        {
            throw new ExceptionBadRequest("Ingrese un nombre válido");
        }
        if (String.IsNullOrEmpty(request.Email))
        {
            throw new ExceptionBadRequest("Ingrese un email válido");
        }
        if (String.IsNullOrEmpty(request.Phone))
        {
            throw new ExceptionBadRequest("Ingrese un teléfono válido");
        }
        if (String.IsNullOrEmpty(request.Password))
        {
            throw new ExceptionBadRequest("Ingrese una contraseña válida");
        }

        var user = new Models.User
        {
            UserTypeId = 1,
            FullName = request.FullName,
            Dni = request.Dni,
            Email = request.Email,
            BirthDate = request.BirthDate,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Phone = request.Phone,
        };

        var createdUser = await _repository.InsertAsync(user);

        return createdUser;
    }
}