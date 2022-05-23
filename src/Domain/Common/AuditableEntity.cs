using System.ComponentModel.DataAnnotations;

namespace chief_schedule.Domain.Common;

public abstract class AuditableEntity
{
    public DateTime Created { get; set; }
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [MaxLength(100)]
    public string? LastModifiedBy { get; set; }
}
