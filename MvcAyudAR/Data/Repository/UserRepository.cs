using MvcAyudAR.Models;
using MvcAyudAR.Services.Interfaces.User;

namespace MvcAyudAR.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> InsertAsync(User user, CancellationToken ct = default)
    {
        await _context.Users.AddAsync(user,ct);
        _context.SaveChangesAsync(ct);
        return user;
    }
}