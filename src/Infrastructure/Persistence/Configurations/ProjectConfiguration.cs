using chief_schedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chief_schedule.Infrastructure.Persistence.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // builder
        //     .HasMany(p => p.Workers)
        //     .WithMany(w => w.Projects)
        //     .UsingEntity("ProjectUser");
        //
        // builder
        //     .HasOne(p => p.Manager)
        //     .WithMany(m => m.Projects)
        //     .HasForeignKey(p => p.ManagerId);
    }
}