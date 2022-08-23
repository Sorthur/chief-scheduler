using chief_schedule.Application.Authentication.Models;
using chief_schedule.Application.Common.Models;

namespace chief_schedule.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<JwtResponse?> AuthorizeJwtAsync(LoginModel loginModel);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}
