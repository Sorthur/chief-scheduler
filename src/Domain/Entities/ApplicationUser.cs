using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace chief_schedule.Domain.Entities;

public class ApplicationUser : IdentityUser, IAuditableEntity
{
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(100)]
    public string? Surname { get; set; }

    public ICollection<Project>? Projects { get; set; }
    
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    
    public string? LastModifiedBy { get; set; }
}
