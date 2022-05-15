using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace chief_schedule.Domain.Entities;

public class Project : AuditableEntity
{
    public ApplicationUser Manager { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    public int TargetNumberOfHours { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<ApplicationUser> Workers { get; set; }
    public ICollection<Note> Notes { get; set; }
}