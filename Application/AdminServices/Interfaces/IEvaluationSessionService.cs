using Domain.Models;

namespace Application.AdminServices.Interfaces;

public interface IEvaluationSessionService
{
    Task<EvaluationSession> CreateSessionAsync(int topicId, ICollection<int> studentIds, ICollection<int> evaluatorIds);
    Task<List<EvaluationSession>> GetAllSessionsAsync();
}
