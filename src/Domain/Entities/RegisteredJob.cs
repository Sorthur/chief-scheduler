namespace chief_schedule.Domain.Entities;

public class RegisteredJob : AuditableEntity
{
    public Guid Id { get; set; }
    public DomainUser? User { get; set; }
    public ProjectTask? ProjectTask { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime StopTime { get; set; }
}