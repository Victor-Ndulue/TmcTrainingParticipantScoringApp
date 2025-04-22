using API.Controllers.Version1.Shared;
using Application.AdminServices.Interfaces;
using Application.Helpers.DTOs.Request;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Admin;

public class UsersController : V1BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("by-role/{role}")]
    public async Task<IActionResult> GetUsersByRole(Roles role)
    {
        var users = await _userService.GetUsersByRoleAsync(role);
        return Ok(users);
    }

    [HttpPost("assign-to-batch")]
    public async Task<IActionResult> AssignToBatch(AssignBatchRequest request)
    {
        await _userService.AssignUserToBatchAsync(request.UserId, request.BatchId);
        return Ok("Assigned successfully");
    }
}
