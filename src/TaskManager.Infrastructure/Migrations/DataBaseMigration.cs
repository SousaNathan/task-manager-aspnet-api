using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Infrastructure.DataAccess;

namespace TaskManager.Infrastructure.Migrations;

public class DataBaseMigration
{
    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<TaskManagerDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
