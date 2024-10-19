using AutoMapper;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(
                user => user.Password,
                config => config.Ignore()
            );
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Task, ResponseRegisterTaskJson>();
        CreateMap<Domain.Entities.Task, ResponseGetTaskJson>();

        CreateMap<User, ResponseUserProfileJson>();
    }
}
