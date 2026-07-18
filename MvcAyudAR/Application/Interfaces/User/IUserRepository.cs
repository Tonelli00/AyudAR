namespace MvcAyudAR.Services.Interfaces.User;

public interface IUserRepository
{
    Task<Domain.Entities.User> InsertAsync(Domain.Entities.User user, CancellationToken ct = default);
    Task<Domain.Entities.User> GetUserByEmailAsync(string email, CancellationToken ct = default);
    Task<Domain.Entities.User> GetUserByIdAsync(Guid Id, CancellationToken ct = default);

}