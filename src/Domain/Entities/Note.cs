using System.ComponentModel.DataAnnotations;

namespace chief_schedule.Domain.Entities;

public class Note : AuditableEntity
{
    public Guid Id { get; set; }
    public Project? Project { get; set; }
    public ApplicationUser? Author { get; set; }
    [MaxLength(100)]
    public string? Title { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
}