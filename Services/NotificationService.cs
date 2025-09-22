using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepo;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepo = notificationRepository;
        }

        //public async Task<Notification?> GetNotificationByIdAsync(long id)
        //{
        //    return await _notificationRepo.GetByIdAsync(id);
        //}

        public async Task<IEnumerable<NotificationDto>> GetNotificationsByAccountIdAsync(long accountId)
        {
            return await _notificationRepo.GetByAccountIdAsync(accountId);
        }

        public async Task<bool> ChangeNotificationStatus(long id)
        {
            var no = await _notificationRepo.GetByIdAsync(id);

            if (no != null)
            {
                no.ReadStatusId = 6;
                _notificationRepo.Update(no);
                await _notificationRepo.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
