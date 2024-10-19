using AutoMapper;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Services.LoggedUser;

namespace TaskManager.Application.UseCases.Tasks.Read.GetAll;

public class GetAllTaskUseCase : IGetAllTaskUseCase
{
    private readonly ITaskReadOnlyRepository _taskReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public GetAllTaskUseCase(
        ITaskReadOnlyRepository taskReadOnlyRepository,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _taskReadOnlyRepository = taskReadOnlyRepository;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseGetTasksJson> Execute()
    {
        var loggedUser = await _loggedUser.Get();
        var tasks = await _taskReadOnlyRepository.GetAll(loggedUser);

        return new ResponseGetTasksJson
        {
            Tasks = _mapper.Map<List<ResponseGetTaskJson>>(tasks)
        };
    }
}
