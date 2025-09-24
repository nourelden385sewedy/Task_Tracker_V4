using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Data.Models;

namespace Task_Tracker_V4.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification?> GetByIdAsync(long id);
        Task<IEnumerable<NotificationDto>> GetByAccountIdAsync(long accountId);
        void Add(Notification notification);
        void Update(Notification notification);
        void Remove(Notification notification);
        Task SaveChangesAsync();
    }
}
