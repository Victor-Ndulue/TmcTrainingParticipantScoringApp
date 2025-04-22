using Domain.Enums;
using Domain.Models;

namespace Application.AdminServices.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersByRoleAsync(Roles role);
    Task AssignUserToBatchAsync(int userId, int batchId);
}
