using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application.AuthServices.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(string fullName, string email, string password, Roles role);
    Task<string?> LoginAsync(string email, string password);
}
