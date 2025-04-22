namespace Domain.Models;

public class EvaluationAssignment
{
    public int Id { get; set; }
    public int EvaluationSessionId { get; set; }
    public virtual EvaluationSession? EvaluationSession { get; set; }
    public int EvaluatorId { get; set; }
    public int StudentId { get; set; }
    public double? Score { get; set; }  // nullable until submitted
    public DateTime? SubmittedAt { get; set; }
}
