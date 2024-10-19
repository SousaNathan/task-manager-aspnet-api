using AutoMapper;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Services.LoggedUser;

namespace TaskManager.Application.UseCases.Users.Read;

public class GetUserUseCase : IGetUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IMapper _mapper;

    public GetUserUseCase(
        ILoggedUser loggedUser,
        IMapper mapper)
    {
        _loggedUser = loggedUser;
        _mapper = mapper;
    }

    public async Task<ResponseUserProfileJson> Execute()
    {
        var user = await _loggedUser.Get();

        return _mapper.Map<ResponseUserProfileJson>(user);
    }
}
