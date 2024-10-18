using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities;

public class Task
{
    public long Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty ;

    [Required]
    public bool IsCompleted { get; set; } = false;

    [Required]
    public string Category { get; set; } = string.Empty ;

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long UserId { get; set; }

    public User User { get; set; } = default!;
}
