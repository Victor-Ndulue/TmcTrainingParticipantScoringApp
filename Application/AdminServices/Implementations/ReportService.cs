using Application.AdminServices.Interfaces;
using Application.Helpers.ViewModels;
using Application.SharedServices.Interfaces;
using Domain.Enums;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminServices.Implementations;

public class ReportService : IReportService
{
    private readonly ApplicationDbContext _context;
    private readonly IPdfExportService _pdfExportService;

    public ReportService(ApplicationDbContext context, IPdfExportService pdfExportService)
    {
        _context = context;
        _pdfExportService = pdfExportService;
    }

    public async Task<byte[]> GenerateBatchScorecardPdfAsync(int batchId)
        => await _pdfExportService.ExportBatchScorecardAsync(batchId);

    public async Task<byte[]> GenerateStudentScorecardPdfAsync(int studentId)
        => await _pdfExportService.ExportStudentScorecardAsync(studentId);

    public async Task<List<StudentScoreHistoryViewModel>> GetHistoricalScoresAsync(int? batchId = null)
    {
        var studentQuery = _context.Users.Where(u => u.Role == Roles.Student);

        if (batchId.HasValue)
        {
            var userIds = await _context.TrainingBatchParticipants
                .Where(p => p.TrainingBatchId == batchId)
                .Select(p => p.UserId)
                .ToListAsync();

            studentQuery = studentQuery.Where(u => userIds.Contains(u.Id));
        }

        var entries = await _context.ScoreboardEntries.ToListAsync();
        var batches = await _context.TrainingBatches.ToListAsync();

        var data = await studentQuery.ToListAsync();

        var history = data.Select(student =>
        {
            var studentEntries = entries.Where(e => e.StudentId == student.Id).ToList();
            var avg = studentEntries.Any() ? studentEntries.Average(e => e.AverageScore ?? 0) : (double?)null;

            var batchName = _context.TrainingBatchParticipants
                .Where(p => p.UserId == student.Id)
                .Include(p => p.TrainingBatch)
                .Select(p => p.TrainingBatch!.Name)
                .FirstOrDefault();

            return new StudentScoreHistoryViewModel
            {
                StudentId = student.Id,
                StudentName = student.FullName,
                OverallAverage = avg,
                BatchName = batchName
            };
        }).ToList();

        return history.OrderBy(h => h.OverallAverage).ToList();
    }
}

