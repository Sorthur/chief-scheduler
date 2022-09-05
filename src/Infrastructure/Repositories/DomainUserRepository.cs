using System.Linq.Expressions;
using chief_schedule.Application.Common.Interfaces.Repositories;
using chief_schedule.Domain.Entities;
using chief_schedule.Infrastructure.Persistence;

namespace chief_schedule.Infrastructure.Repositories;

public class DomainUserRepository : BaseRepository<DomainUser>, IDomainUserRepository
{
    public DomainUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}