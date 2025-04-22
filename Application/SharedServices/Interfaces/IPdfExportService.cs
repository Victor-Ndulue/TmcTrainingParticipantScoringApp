namespace Application.SharedServices.Interfaces;

public interface IPdfExportService
{
    Task<byte[]> ExportStudentScorecardAsync(int studentId);
    Task<byte[]> ExportBatchScorecardAsync(int batchId);
}
