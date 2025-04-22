namespace Domain.Models;

public class ScoreboardEntry
{
    public int StudentId { get; set; }
    public int TopicId { get; set; }
    public double? AverageScore { get; set; }
}
