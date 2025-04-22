using Domain.Enums;

namespace Application.Helpers.DTOs.Request;

public record RegisterRequest(string FullName, string Email, string Password, Roles Role);
