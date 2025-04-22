using API.Controllers.Version1.Shared;
using Application.StudentServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Student;

public class DashboardController : V1BaseController
{
    private readonly IStudentDashboardService _studentDashboardService;

    public DashboardController(IStudentDashboardService studentDashboardService)
    {
        _studentDashboardService = studentDashboardService;
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentDashboard(int studentId)
        => Ok(await _studentDashboardService.GetDashboardAsync(studentId));
}
