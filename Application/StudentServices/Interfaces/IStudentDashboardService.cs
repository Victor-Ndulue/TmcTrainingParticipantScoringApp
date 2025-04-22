using Application.Helpers.ViewModels;

namespace Application.StudentServices.Interfaces;

public interface IStudentDashboardService
{
    Task<StudentScoreViewModel> GetDashboardAsync(int studentId);
}
