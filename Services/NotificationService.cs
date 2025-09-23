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

        public async Task<bool> DeleteNotification(long id)
        {
            var not = await _notificationRepo.GetByIdAsync(id);

            if (not != null)
            {
                not.isActive = false;
                _notificationRepo.Update(not);
                await _notificationRepo.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task CreateNotificationNewTaskAsync()
        {

        }

        public async Task CreateNotificationUpdateTaskStatusAsync()
        {

        }



        /*
        public async TaskSys CreateNotificationNewTaskAsync(string assignedToName, string taskname)
        {

            Notification notification = new Notification()
            {
                Title = "New Task Assigned",
                Message = $"You have been assigned to {taskname}",
                AccountId = await _accountRepo.GetIdByNameAsync(assignedToName),
                ReadStatusId = (long)StatusEnum.UnRead
            };

            _notificationRepo.Add(notification);
            await _notificationRepo.SaveChangesAsync();
        } 
        */
        /*
        public async TaskSys CreateNotificationUpdateTaskStatusAsync(long? accountId, string taskname, long statusId)
        {

            string status = ((StatusEnum)statusId).ToString();

            Notification notification = new Notification()
            {
                Title = "Task Status Updated",
                Message = $"{taskname} has been marked as {status}",
                AccountId = accountId,
                ReadStatusId = (long)StatusEnum.UnRead
            };

            _notificationRepo.Add(notification);
            await _notificationRepo.SaveChangesAsync();
        } 
        */
    }
}
