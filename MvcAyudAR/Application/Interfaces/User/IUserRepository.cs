namespace MvcAyudAR.Services.Interfaces.User;

public interface IUserRepository
{
    Task<Models.User> InsertAsync(Models.User user, CancellationToken ct = default);
    Task<Models.User> GetUserByEmailAsync(string email, CancellationToken ct = default);

}