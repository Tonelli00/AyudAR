using MvcAyudAR.Models.DTOs.User;

namespace MvcAyudAR.Services.Interfaces.User;

public interface ILoginUserHandler
{
    Task<bool> LoginHandler(LoginRequestDTO request);
}