using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace chief_schedule.Domain.Entities;

public class Project : AuditableEntity
{
    public Guid Id { get; set; }
    public Guid? ManagerId { get; set; }
    public DomainUser? Manager { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    public int TargetNumberOfHours { get; set; }
    public ICollection<ProjectTask>? Tasks { get; set; }
    public ICollection<DomainUser> Workers { get; set; }
    public ICollection<Note>? Notes { get; set; }
}