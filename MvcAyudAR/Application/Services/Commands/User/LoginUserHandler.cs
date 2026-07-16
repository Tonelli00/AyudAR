using MvcAyudAR.Application.DTOs.User;
using MvcAyudAR.Models.Exceptions;
using MvcAyudAR.Services.Interfaces.User;

namespace MvcAyudAR.Services.Commands.User;

public class LoginUserHandler:ILoginUserHandler
{
    private readonly IUserRepository _repository;

    public LoginUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> LoginHandler(LoginRequestDTO request)
    {
        var user = await _repository.GetUserByEmailAsync(request.Email) ?? throw new ExceptionNotFound("Usuario no encontrado");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new ExceptionBadRequest("Credenciales invalidas");
        }

        return true; 
    }
}