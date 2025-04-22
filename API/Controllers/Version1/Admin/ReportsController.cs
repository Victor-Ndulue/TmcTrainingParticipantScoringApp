using API.Controllers.Version1.Shared;
using Application.AdminServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Version1.Admin;

public class ReportsController : V1BaseController
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("student/{studentId}/pdf")]
    public async Task<IActionResult> ExportStudentPdf(int studentId)
    {
        var file = await _reportService.GenerateStudentScorecardPdfAsync(studentId);
        return File(file, "application/pdf", $"student_{studentId}_scorecard.pdf");
    }

    [HttpGet("batch/{batchId}/pdf")]
    public async Task<IActionResult> ExportBatchPdf(int batchId)
    {
        var file = await _reportService.GenerateBatchScorecardPdfAsync(batchId);
        return File(file, "application/pdf", $"batch_{batchId}_scorecard.pdf");
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory([FromQuery] int? batchId = null)
        => Ok(await _reportService.GetHistoricalScoresAsync(batchId));
}
