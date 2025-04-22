using Application.AdminServices.Interfaces;
using Domain.Enums;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminServices.Implementations;

public class EvaluationSessionService : IEvaluationSessionService
{
    private readonly ApplicationDbContext _context;

    public EvaluationSessionService(ApplicationDbContext context) => _context = context;

    public async Task<EvaluationSession> CreateSessionAsync(int topicId, ICollection<int> studentIds, ICollection<int> evaluatorIds)
    {
        var evaluators = await _context.Users.Where(u => evaluatorIds.Contains(u.Id) && u.Role == Roles.Evaluator).ToListAsync();

        var session = new EvaluationSession
        {
            TopicId = topicId,
            CreatedAt = DateTime.UtcNow,
            Assignments = new List<EvaluationAssignment>()
        };

        foreach (var studentId in studentIds)
        {
            foreach (var evaluator in evaluators)
            {
                session.Assignments.Add(new EvaluationAssignment
                {
                    StudentId = studentId,
                    EvaluatorId = evaluator.Id
                });
            }
        }

        _context.EvaluationSessions.Add(session);
        await _context.SaveChangesAsync();

        return session;
    }

    public async Task<List<EvaluationSession>> GetAllSessionsAsync() =>
        await _context.EvaluationSessions.Include(s => s.Assignments).ToListAsync();
}

