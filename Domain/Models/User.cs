using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class User : IdentityUser<int>  // int as PK
{
    public string? FullName { get; set; }
    public Roles Role { get; set; } // "Student", "Evaluator", "Admin"
}