using TaskManager.Domain.Repositories;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Exception.ExceptionBase;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Tasks.Delete;

public class DeleteTaskUseCase : IDeleteTaskUseCase
{
    private readonly ITaskReadOnlyRepository _taskReadOnlyRepository;
    private readonly ITaskWriteOnlyRepository _taskWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggeUser;

    public DeleteTaskUseCase(
        ITaskReadOnlyRepository taskReadOnlyRepository,
        ITaskWriteOnlyRepository taskWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser)
    {
        _taskReadOnlyRepository = taskReadOnlyRepository;
        _taskWriteOnlyRepository = taskWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _loggeUser = loggedUser;
    }

    public async Task Execute(long id)
    {
        var loggedUser = await _loggeUser.Get();
        var expense = await _taskReadOnlyRepository.GetById(loggedUser, id);

        if (expense is null)
            throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND);

        await _taskWriteOnlyRepository.Delete(id);
        await _unitOfWork.Commit();
    }
}
