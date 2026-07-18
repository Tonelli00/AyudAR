
using MvcAyudAR.Application.DTOs.User;

namespace MvcAyudAR.Services.Interfaces.User;

public interface ICreateUserHandler
{
    Task<MvcAyudAR.Domain.Entities.User> CreateUser(UserRequestDTO request);
}