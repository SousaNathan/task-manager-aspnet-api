using AutoMapper;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Exception.ExceptionBase;
using TaskManager.Exception.Resource;

namespace TaskManager.Application.UseCases.Tasks.Read.GetById;

public class GetTaskByIdUseCase : IGetTaskByIdUseCase
{
    private readonly ITaskReadOnlyRepository _taskReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetTaskByIdUseCase(
        ITaskReadOnlyRepository taskReadOnlyRepository,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _taskReadOnlyRepository = taskReadOnlyRepository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseGetTaskJson> Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();
        var task = await _taskReadOnlyRepository.GetById(loggedUser, id);

        return task is null
            ? throw new NotFoundException(ResourceErrorMessages.TASK_NOT_FOUND)
            : _mapper.Map<ResponseGetTaskJson>(task);
    }
}
