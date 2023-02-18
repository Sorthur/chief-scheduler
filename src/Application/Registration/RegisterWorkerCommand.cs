using chief_schedule.Application.Authentication.Models;
using chief_schedule.Application.Common.Interfaces;
using chief_schedule.Application.Common.Interfaces.Repositories;
using chief_schedule.Domain.Entities;
using MediatR;

public record RegisterWorkerCommand(RegisterModel model) : IRequest;

public class RegisterWorkerCommandHandler : IRequestHandler<RegisterWorkerCommand, Unit>
{
    private readonly IIdentityService _identityService;
    private readonly IDomainUserRepository _domainUserRepository;

    public RegisterWorkerCommandHandler(IIdentityService identityService, IDomainUserRepository domainUserRepository)
    {
        _identityService = identityService;
        _domainUserRepository = domainUserRepository;
    }

    async Task<Unit> IRequestHandler<RegisterWorkerCommand, Unit>.Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
    {
        var result = _identityService.CreateWorkerAsync(request.model);
        if (!result.Result.result.Succeeded) throw new ArgumentException(string.Join(Environment.NewLine, result.Result.result.Errors));

        var newDomainUser = new DomainUser
        {
            Id = new(),
            ApplicationUserId = result.Result.userId,
            Created = DateTime.Now,
            LastModified = DateTime.Now
        };

        await _domainUserRepository.AddAsync(newDomainUser);
        await _domainUserRepository.SaveChangesAsync();

        // todo: sending mail with password

        return Unit.Value;
    }
}