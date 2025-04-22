namespace Application.Helpers.ViewModels;

public class StudentScoreViewModel
{
    public int StudentId { get; set; }
    public string? StudentName { get; set; }
    public Dictionary<string, double?> TopicScores { get; set; } = new();
    public double? OverallAverage => TopicScores.Any() ? TopicScores.Values.Average() : 0;
}