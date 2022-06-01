// using chief_schedule.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace chief_schedule.Infrastructure.Persistence.Configurations;
//
// public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
// {
//     public void Configure(EntityTypeBuilder<UserProject> builder)
//     {
//         builder.HasKey(up => new {up.UserId, up.ProjectId});
//         builder
//             .HasOne(up => up.Project)
//             .WithMany(up => up.Workers);
//     }
// }