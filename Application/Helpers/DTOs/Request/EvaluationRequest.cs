namespace Application.Helpers.DTOs.Request;

public record EvaluationRequest(int EvaluatorId, int StudentId, int TopicId, double Score);
