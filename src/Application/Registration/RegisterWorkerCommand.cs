using chief_schedule.Application.Authentication.Models;
using chief_schedule.Application.Common.Interfaces;
using chief_schedule.Application.Common.Interfaces.Repositories;
using chief_schedule.Domain.Entities;
using MediatR;

public record RegisterWorkerCommand(RegisterModel model) : IRequest;

public class RegisterWorkerCommandHandler : IRequestHandler<RegisterWorkerCommand, Unit>
{
    private readonly IIdentityService _identityService;

    public RegisterWorkerCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    async Task<Unit> IRequestHandler<RegisterWorkerCommand, Unit>.Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
    {
        // registration

        // sending mail with password

        return Unit.Value;
    }
}