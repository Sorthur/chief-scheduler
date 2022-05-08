using chief_schedule.Application.Common.Interfaces;

namespace chief_schedule.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
