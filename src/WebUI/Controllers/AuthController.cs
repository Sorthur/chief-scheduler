using chief_schedule.Application.Authentication.Models;
using chief_schedule.Application.Common.Interfaces;
using chief_schedule.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chief_schedule.WebUI.Controllers;

public class AuthController : ApiControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var token = await _identityService.AuthorizeJwtAsync(model);

        return token != null
            ? Ok(token)
            : BadRequest("Bad login or password");
    }

    [HttpPost("register-worker")]
    [Authorize(Roles = $"{RoleName.MANAGER},{RoleName.ADMINISTRATOR}")]
    public async Task<IActionResult> RegisterWorker([FromBody] RegisterWorkerCommand request) => Ok(Mediator.Send(request));
}