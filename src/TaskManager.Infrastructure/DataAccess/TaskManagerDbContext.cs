using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.DataAccess;

internal class TaskManagerDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Name).HasColumnName("name");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.CreatedAt).HasColumnName("created_at");
            entity.Property(u => u.UserIdentifier).HasColumnName("user_identifier");
        });

        modelBuilder.Entity<Domain.Entities.Task>(entity =>
        {
            entity.ToTable("tasks");
            entity.Property(t => t.Id).HasColumnName("id");
            entity.Property(t => t.Title).HasColumnName("title");
            entity.Property(t => t.Description).HasColumnName("description");
            entity.Property(t => t.IsCompleted).HasColumnName("is_completed");
            entity.Property(t => t.Category).HasColumnName("category");
            entity.Property(t => t.CreatedAt).HasColumnName("created_at");
            entity.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            entity.Property(t => t.UserId).HasColumnName("user_id");
        });
    }
}
