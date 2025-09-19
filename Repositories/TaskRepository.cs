using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public void Add(TblTask task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetByAssignedByIdAsync(long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetByAssignedToAsync(long accountId)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetByNotAssignedByAsync(long accountId)
        {
            throw new NotImplementedException();
        }

        public void Remove(TblTask task)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TblTask task)
        {
            throw new NotImplementedException();
        }
    }
}
