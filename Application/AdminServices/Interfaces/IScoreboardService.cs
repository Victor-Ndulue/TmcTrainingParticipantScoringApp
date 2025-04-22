using Application.Helpers.ViewModels;

namespace Application.AdminServices.Interfaces;

public interface IScoreboardService
{
    Task<IEnumerable<StudentScoreViewModel>> GetScoreboardAsync();
}
