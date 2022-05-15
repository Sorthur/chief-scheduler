using System.ComponentModel.DataAnnotations;

namespace chief_schedule.Domain.Entities;

public class ProjectTask : AuditableEntity
{
    public Guid Id { get; set; }
    public Project Project { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    public int TargetNumberOfHours { get; set; }
}