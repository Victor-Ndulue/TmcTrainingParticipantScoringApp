namespace Domain.Models;

public class EvaluationSession
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<EvaluationAssignment>? Assignments { get; set; }
}
