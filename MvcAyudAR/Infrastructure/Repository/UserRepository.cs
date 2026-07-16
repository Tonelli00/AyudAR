using Microsoft.EntityFrameworkCore;
using MvcAyudAR.Infrastructure.Persistence;
using MvcAyudAR.Models;
using MvcAyudAR.Services.Interfaces.User;

namespace MvcAyudAR.Infrastructure.Repository;

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
        await _context.SaveChangesAsync(ct);
        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email, CancellationToken ct = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
    }
}