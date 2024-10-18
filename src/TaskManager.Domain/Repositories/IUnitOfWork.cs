namespace TaskManager.Domain.Repositories;

public interface IUnitOfWork
{
    System.Threading.Tasks.Task Commit();
}
