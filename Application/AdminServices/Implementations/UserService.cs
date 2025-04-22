using Application.AdminServices.Interfaces;
using Domain.Enums;
using Domain.Models;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminServices.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(Roles role) =>
            await _context.Users.Where(u => u.Role == role).ToListAsync();

        public async Task AssignUserToBatchAsync(int userId, int batchId)
        {
            var user = await _context.Users.FindAsync(userId);
            var batch = await _context.TrainingBatches.FindAsync(batchId);

            if (user == null || batch == null)
                throw new Exception("User or batch not found");

            var exists = await _context.TrainingBatchParticipants
                .AnyAsync(p => p.UserId == userId && p.TrainingBatchId == batchId);

            if (!exists)
            {
                var assignment = new TrainingBatchParticipant
                {
                    UserId = userId,
                    TrainingBatchId = batchId
                };

                _context.TrainingBatchParticipants.Add(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
