using TaskManager.Domain.Repositories;

namespace TaskManager.Infrastructure.DataAccess;

internal class UnitOfWork(TaskManagerDbContext dbContext) : IUnitOfWork
{
    private readonly TaskManagerDbContext _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
