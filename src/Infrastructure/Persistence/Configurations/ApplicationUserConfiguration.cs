using chief_schedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chief_schedule.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasMany(u => u.Projects)
            .WithMany(p => p.Workers)
            .UsingEntity(b => b.ToTable("UserProject"));

        builder
            .HasMany(u => u.ManagedProjects)
            .WithOne(p => p.Manager)
            .HasForeignKey(p => p.ManagerId);
    }
}