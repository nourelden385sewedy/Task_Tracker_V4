using Task_Tracker_V4.Models;

namespace Task_Tracker_V4.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification?> GetByIdAsync(long id);
        Task<IEnumerable<Notification>> GetByAccountIdAsync(long accountId);
        void Add(Notification notification);
        void Update(Notification notification);
        void Remove(Notification notification);
        Task SaveChangesAsync();
    }
}
