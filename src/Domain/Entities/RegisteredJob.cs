namespace chief_schedule.Domain.Entities;

public class RegisteredJob : AuditableEntity
{
    public Guid Id { get; set; }
    public ApplicationUser User { get; set; }
    public Task Task { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime StopTime { get; set; }
}