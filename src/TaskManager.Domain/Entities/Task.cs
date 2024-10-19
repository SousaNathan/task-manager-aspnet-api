using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities;

public class Task
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty ;

    [Required]
    public bool IsCompleted { get; set; } = false;

    [Required]
    public string Category { get; set; } = string.Empty ;

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime? UpdatedAt { get; set; }

    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = default!;
}
