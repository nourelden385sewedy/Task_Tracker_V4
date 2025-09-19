using Microsoft.EntityFrameworkCore;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MyDbContext _context;

        public NotificationRepository(MyDbContext context)
        {
            _context = context;
        }


        public async Task<Notification?> GetByIdAsync(long id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<NotificationDto>> GetByAccountIdAsync(long accountId)
        {
            return await _context.Notifications
                .Where(n => n.AccountId == accountId && n.isActive == true)
                .Select(n => new NotificationDto { 
                    Id = n.Id,
                    AccountId = n.AccountId,
                    Title = n.Title,
                    Message = n.Message,
                    isRead = StatusMapper.MapReadStatusBoolean(n.ReadStatusId),
                    CreatedAt = n.CreatedAt
                }).ToListAsync();
        }

        public void Update(Notification notification)
        {
            _context.Notifications.Update(notification);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // --------------------

        public void Add(Notification notification)
        {
            throw new NotImplementedException();
        }

        public void Remove(Notification notification)
        {
            throw new NotImplementedException();
        }

        
    }
}
