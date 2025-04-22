using Domain.Models;

namespace Application.AdminServices.Interfaces;

public interface ITopicService
{
    Task<List<Topic>> GetAllTopicsAsync();
    Task<Topic> CreateTopicAsync(string name);
    Task<Topic?> UpdateTopicAsync(int id, string newName);
    Task<bool> DeleteTopicAsync(int id);
}
