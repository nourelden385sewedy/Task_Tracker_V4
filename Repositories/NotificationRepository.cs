using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public void Add(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetByAccountIdAsync(long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Notification?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
