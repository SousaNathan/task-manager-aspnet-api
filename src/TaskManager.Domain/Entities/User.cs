using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities;

public class User
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public Guid UserIdentifier { get; set; }

    public ICollection<Task> Tasks { get; set; } = [];
}
