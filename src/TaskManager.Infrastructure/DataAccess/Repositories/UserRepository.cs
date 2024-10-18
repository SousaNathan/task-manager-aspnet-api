using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.User;

namespace TaskManager.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
   private readonly TaskManagerDbContext _dbContext;

    public UserRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async System.Threading.Tasks.Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users
            .AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User> GetById(long id)
    {
        return await _dbContext.Users
            .FirstAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }

    public async System.Threading.Tasks.Task Delete(User user)
    {
        var userToRemove = await _dbContext.Users
            .FindAsync(user.Id);

        _dbContext.Users.Remove(userToRemove!);
    }
}
