using Application.AdminServices.Interfaces;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminServices.Implementations;

public class TopicService : ITopicService
{
    private readonly ApplicationDbContext _context;

    public TopicService(ApplicationDbContext context) => _context = context;

    public async Task<List<Topic>> GetAllTopicsAsync() =>
        await _context.Topics.ToListAsync();

    public async Task<Topic> CreateTopicAsync(string name)
    {
        var topic = new Topic { Name = name };
        _context.Topics.Add(topic);
        await _context.SaveChangesAsync();
        return topic;
    }

    public async Task<Topic?> UpdateTopicAsync(int id, string newName)
    {
        var topic = await _context.Topics.FindAsync(id);
        if (topic == null) return null;
        topic.Name = newName;
        await _context.SaveChangesAsync();
        return topic;
    }

    public async Task<bool> DeleteTopicAsync(int id)
    {
        var topic = await _context.Topics.FindAsync(id);
        if (topic == null) return false;
        _context.Topics.Remove(topic);
        await _context.SaveChangesAsync();
        return true;
    }
}
