using Microsoft.EntityFrameworkCore;
using ToDo_Task_DataAccess;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.IRepositories;

namespace ToDo_Task_Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Register(User user)
    {
        var userDb = await _context.Users
            .SingleOrDefaultAsync(x => x.UserName == user.UserName);
        if (userDb is not null)
            return false;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Login(User user)
    {
        var userDb = await _context.Users
            .SingleOrDefaultAsync(x => x.UserName == user.UserName && x.PassWord == user.PassWord);
        if (userDb is null)
        {// throw new not
        }
        return true;
    }

    public async Task<User> GetUserById(int userId)
        => (await _context.Users.SingleOrDefaultAsync(x => x.Id == userId))!;
}