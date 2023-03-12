using chief_schedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chief_schedule.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<DomainUser>
{
    public void Configure(EntityTypeBuilder<DomainUser> builder)
    {
        builder
            .HasMany(u => u.Projects)
            .WithMany(p => p.Workers)
            .UsingEntity(b => b.ToTable("UserProject"));

        builder
            .HasMany(u => u.ManagedProjects)
            .WithOne(p => p.Manager)
            .HasForeignKey("ManagerId");
    }
}