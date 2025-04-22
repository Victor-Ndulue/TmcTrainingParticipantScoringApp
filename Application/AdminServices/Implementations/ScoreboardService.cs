using Application.AdminServices.Interfaces;
using Application.Helpers.ViewModels;
using Domain.Enums;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminServices.Implementations;

public class ScoreboardService : IScoreboardService
{
    private readonly ApplicationDbContext _context;

    public ScoreboardService(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<StudentScoreViewModel>> GetScoreboardAsync()
    {
        var students = await _context.Users
            .Where(u => u.Role == Roles.Student)
            .ToListAsync();

        var topics = await _context.Topics.ToListAsync();
        var entries = await _context.ScoreboardEntries.ToListAsync();

        var viewModels = students.Select(student => new StudentScoreViewModel
        {
            StudentId = student.Id,
            StudentName = student.FullName,
            TopicScores = topics.ToDictionary(
                topic => topic.Name,
                topic => entries.FirstOrDefault(e => e.StudentId == student.Id && e.TopicId == topic.Id)?.AverageScore
            )
        }).ToList();

        return viewModels;
    }
}
