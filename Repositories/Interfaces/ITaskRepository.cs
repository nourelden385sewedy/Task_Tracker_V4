using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Models;

namespace Task_Tracker_V4.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskDto?> GetByIdAsync(long id);
        Task<TblTask?> GetFullTaskByIdAsync(long id);
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<IEnumerable<TaskDto>> GetByAssignedToAsync(long accountId);
        Task<IEnumerable<TaskDto>> GetByAssignedByIdAsync(long accountId);
        Task<IEnumerable<TaskDto>> GetByNotAssignedByAsync(long accountId);
        void Add(TblTask task);
        void Update(TblTask task);
        void Remove(TblTask task);
        Task SaveChangesAsync();
    }
}
