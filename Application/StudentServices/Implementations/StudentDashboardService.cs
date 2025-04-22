using Application.Helpers.ViewModels;
using Application.StudentServices.Interfaces;
using Domain.Enums;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.StudentServices.Implementations;

public class StudentDashboardService : IStudentDashboardService
{
    private readonly ApplicationDbContext _context;

    public StudentDashboardService(ApplicationDbContext context) => _context = context;

    public async Task<StudentScoreViewModel> GetDashboardAsync(int studentId)
    {
        var student = await _context.Users.FindAsync(studentId);
        if (student == null || student.Role != Roles.Student)
            throw new Exception("Invalid student");

        var topics = await _context.Topics.ToListAsync();
        var scores = await _context.ScoreboardEntries
            .Where(e => e.StudentId == studentId)
            .ToListAsync();

        var result = new StudentScoreViewModel
        {
            StudentName = student.FullName,
            TopicScores = topics.ToDictionary(
                t => t.Name,
                t => scores.FirstOrDefault(s => s.TopicId == t.Id)?.AverageScore
            )
        };

        return result;
    }
}

