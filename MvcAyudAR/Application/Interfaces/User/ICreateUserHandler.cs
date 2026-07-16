
using MvcAyudAR.Application.DTOs.User;

namespace MvcAyudAR.Services.Interfaces.User;

public interface ICreateUserHandler
{
    Task<MvcAyudAR.Models.User> CreateUser(UserRequestDTO request);
}