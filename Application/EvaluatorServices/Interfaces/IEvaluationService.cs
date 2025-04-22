namespace Application.EvaluatorServices.Interfaces;

public interface IEvaluationService
{
    Task SubmitScoreAsync(int evaluatorId, int studentId, int topicId, double score);
    Task<double?> GetAverageScoreAsync(int studentId, int topicId);
    Task<bool> AreAllScoresSubmitted(int studentId, int topicId);
}
