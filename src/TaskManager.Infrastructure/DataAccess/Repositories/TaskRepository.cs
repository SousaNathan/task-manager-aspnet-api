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

    public async System.Threading.Tasks.Task Add(Domain.Entities.Task task)
    {
        await _dbContext.Tasks
            .AddAsync(task);
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

    public void Update(Domain.Entities.Task task)
    {
        _dbContext.Update(task);
    }

    public async System.Threading.Tasks.Task Delete(long id)
    {
        var task = await _dbContext.Tasks
            .FirstAsync(e => e.Id == id);

        _dbContext.Tasks.Remove(task);
    }
}
