using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Repositories.User;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.DataAccess;
using TaskManager.Infrastructure.DataAccess.Repositories;
using TaskManager.Domain.Repositories.Task;
using TaskManager.Domain.Security.Tokens;
using TaskManager.Infrastructure.Security.Tokens;
using TaskManager.Domain.Security.Cryptography;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Infrastructure.Services.LoggedUser;

namespace TaskManager.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();

        AddToken(services, configuration);
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    public static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
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
        var connectionString = configuration.GetConnectionString("PostgresConnection");

        services.AddDbContext<TaskManagerDbContext>(config =>
            config.UseNpgsql(connectionString)); ;
    }
}
