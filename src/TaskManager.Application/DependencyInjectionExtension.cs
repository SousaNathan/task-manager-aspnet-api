using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.AutoMapper;
using TaskManager.Application.UseCases.Login.DoLogin;
using TaskManager.Application.UseCases.Tasks.Create;
using TaskManager.Application.UseCases.Tasks.Read.GetAll;
using TaskManager.Application.UseCases.Tasks.Read.GetById;
using TaskManager.Application.UseCases.Tasks.Update;
using TaskManager.Application.UseCases.Users.ChangePassword;
using TaskManager.Application.UseCases.Users.Create;
using TaskManager.Application.UseCases.Users.Delete;
using TaskManager.Application.UseCases.Users.Read;
using TaskManager.Application.UseCases.Users.Update;

namespace TaskManager.Application;

public static class DependencyInjectionExtension
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetUserUseCase, GetUserUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IRegisterTaskUseCase, RegisterTaskUseCase>();
        services.AddScoped<IGetTaskByIdUseCase, GetTaskByIdUseCase>();
        services.AddScoped<IGetAllTaskUseCase, GetAllTaskUseCase>();
        services.AddScoped<IUpdateTaskUseCase, UpdateTaskUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();

    }
}
