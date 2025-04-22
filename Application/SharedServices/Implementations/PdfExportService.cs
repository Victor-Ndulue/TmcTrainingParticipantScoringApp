using Application.SharedServices.Interfaces;
using Application.StudentServices.Interfaces;
using QuestPDF.Fluent;

namespace Application.SharedServices.Implementations;

public class PdfExportService : IPdfExportService
{
    private readonly IStudentDashboardService _studentDashboardService;

    public PdfExportService(IStudentDashboardService studentDashboardService)
    {
        _studentDashboardService = studentDashboardService;
    }

    public async Task<byte[]> ExportStudentScorecardAsync(int studentId)
    {
        var dashboard = await _studentDashboardService.GetDashboardAsync(studentId);

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Content().Column(col =>
                {
                    col.Item().Text($"Scorecard for {dashboard.StudentName}").FontSize(18).Bold();

                    foreach (var (topic, score) in dashboard.TopicScores)
                    {
                        col.Item().Text($"{topic}: {score ?? 0}");
                    }

                    col.Item().Text($"Overall Avg: {dashboard.OverallAverage ?? 0}");
                });
            });
        });

        return doc.GeneratePdf();
    }

    public async Task<byte[]> ExportBatchScorecardAsync(int batchId)
    {
        // Placeholder for batch-level export (requires gathering all student data)
        return await Task.FromResult(new byte[0]);
    }
}

