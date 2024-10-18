using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories.Task;

namespace TaskManager.Infrastructure.DataAccess.Repositories;

internal class TaskRepository : ITaskReadOnlyRepository, ITaskWriteOnlyRepository, ITaskUpdateOnlyRepository
{
    private readonly TaskManagerDbContext _dbContext;

    public TaskRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async System.Threading.Tasks.Task Add(Domain.Entities.Task expense)
    {
        await _dbContext.Tasks
            .AddAsync(expense);
    }

    public async Task<List<Domain.Entities.Task>> GetAll(User user)
    {
        return await _dbContext.Tasks
            .AsNoTracking()
            .Where(e => e.UserId == user.Id)
            .ToListAsync();
    }

    async Task<Domain.Entities.Task?> ITaskReadOnlyRepository.GetById(User user, long id)
    {
        return await _dbContext.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
    }

    async Task<Domain.Entities.Task?> ITaskUpdateOnlyRepository.GetById(User user, long id)
    {
        return await _dbContext.Tasks
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
    }

    public void Update(Domain.Entities.Task expense)
    {
        _dbContext.Update(expense);
    }

    public async System.Threading.Tasks.Task Delete(long id)
    {
        var expense = await _dbContext.Tasks
            .FirstAsync(e => e.Id == id);

        _dbContext.Tasks.Remove(expense);
    }
}
