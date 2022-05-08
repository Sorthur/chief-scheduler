using chief_schedule.Domain.Common;

namespace chief_schedule.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
