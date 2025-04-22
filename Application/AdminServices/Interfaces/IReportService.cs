using Application.Helpers.ViewModels;

namespace Application.AdminServices.Interfaces;

public interface IReportService
{
    Task<byte[]> GenerateBatchScorecardPdfAsync(int batchId);
    Task<byte[]> GenerateStudentScorecardPdfAsync(int studentId);
    Task<List<StudentScoreHistoryViewModel>> GetHistoricalScoresAsync(int? batchId = null);
}
