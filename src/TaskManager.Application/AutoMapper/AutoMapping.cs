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

        CreateMap<RequestRegisterTaskJson, Domain.Entities.Task>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Domain.Entities.Task, ResponseRegisterTaskJson>();
        CreateMap<Domain.Entities.Task, ResponseGetTaskJson>();
        CreateMap<Domain.Entities.Task, RequestRegisterTaskJson>();

        CreateMap<User, ResponseUserProfileJson>();
    }
}
