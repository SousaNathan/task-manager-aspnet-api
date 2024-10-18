using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Repositories.User;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.DataAccess;
using TaskManager.Infrastructure.DataAccess.Repositories;
using TaskManager.Domain.Repositories.Task;

namespace TaskManager.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITaskReadOnlyRepository, TaskRepository>();
        services.AddScoped<ITaskWriteOnlyRepository, TaskRepository>();
        services.AddScoped<ITaskUpdateOnlyRepository, TaskRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreConnection");

        services.AddDbContext<TaskManagerDbContext>(config =>
            config.UseNpgsql(connectionString)); ;
    }
}
