using Application.EvaluatorServices.Interfaces;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EvaluatorServices.Implementations;

public class EvaluationService : IEvaluationService
{
    private readonly ApplicationDbContext _context;

    public EvaluationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SubmitScoreAsync(int evaluatorId, int studentId, int topicId, double score)
    {
        var assignment = await _context.EvaluationAssignments
            .FirstOrDefaultAsync(x =>
                x.EvaluatorId == evaluatorId &&
                x.StudentId == studentId &&
                x.EvaluationSession.TopicId == topicId);

        if (assignment == null)
            throw new Exception("Assignment not found");

        assignment.Score = score;
        assignment.SubmittedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        if (await AreAllScoresSubmitted(studentId, topicId))
        {
            var average = await _context.EvaluationAssignments
                .Where(x => x.StudentId == studentId && x.EvaluationSession.TopicId == topicId)
                .AverageAsync(x => x.Score);

            var entry = await _context.ScoreboardEntries
                .FirstOrDefaultAsync(x => x.StudentId == studentId && x.TopicId == topicId);

            if (entry == null)
            {
                entry = new ScoreboardEntry { StudentId = studentId, TopicId = topicId, AverageScore = average };
                _context.ScoreboardEntries.Add(entry);
            }
            else
            {
                entry.AverageScore = average;
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<double?> GetAverageScoreAsync(int studentId, int topicId)
    {
        return await _context.ScoreboardEntries
            .Where(x => x.StudentId == studentId && x.TopicId == topicId)
            .Select(x => x.AverageScore)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> AreAllScoresSubmitted(int studentId, int topicId)
    {
        return !await _context.EvaluationAssignments
            .Where(x => x.StudentId == studentId && x.EvaluationSession.TopicId == topicId)
            .AnyAsync(x => x.Score == null);
    }
}
