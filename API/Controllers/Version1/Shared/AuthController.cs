using Application.AuthServices.Interfaces;
using Application.Helpers.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Shared;

public class AuthController : V1BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request.FullName, request.Email, request.Password, request.Role);
        return result.Succeeded ? Ok("Registration successful") : BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);
        return token == null ? Unauthorized() : Ok(new { Token = token });
    }
}
