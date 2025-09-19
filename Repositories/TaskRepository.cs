using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly MyDbContext _context;
        public TaskRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto?> GetByIdAsync(long id)
        {
            var task = await _context.TblTasks.FirstOrDefaultAsync(t => t.Id == id && t.StatusId != 2);

            if (task != null)
            {
                TaskDto taskDto = new TaskDto()
                {
                    Id = task.Id,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    AssignedToName = _context.Accounts
                        .Where(a => a.Id == task.AssignedToId)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    AssignedByName = _context.Accounts
                        .Where(a => a.Id == task.AssignedById)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    Status = StatusMapper.MapToStatus(task.StatusId),
                    CreatedAt = task.CreatedAt,
                    DueDate = task.TaskDeadline
                };

                return taskDto;
            }


            return null;
        }

        public async Task<TblTask?> GetFullTaskByIdAsync(long id)
        {
            var task = await _context.TblTasks.FirstOrDefaultAsync(t => t.Id == id && t.StatusId != 2);
            return task;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            return await _context.TblTasks
                .Select(t => new TaskDto
                {

                }).ToListAsync();
        }

        public async Task<IEnumerable<TaskDto>> GetByAssignedByIdAsync(long accountId)
        {
            var AssignedByName = await _context.Accounts
                .Where(x => x.Id == accountId).Select(a => a.FullNameAr)
                .FirstOrDefaultAsync();

            return await _context.TblTasks
                .Where(x => x.AssignedById == accountId && x.AdminAccountId == null && x.StatusId != 2)
                .Select(x => new TaskDto
                {
                    Id = x.Id,
                    TaskName = x.TaskName,
                    TaskDescription = x.TaskDescription,
                    AssignedToName = _context.Accounts
                        .Where(a => a.Id == x.AssignedToId)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    AssignedByName = AssignedByName,
                    Status = StatusMapper.MapToStatus(x.StatusId),
                    CreatedAt = x.CreatedAt,
                    DueDate = x.TaskDeadline,
                }).ToListAsync();
        }

        public async Task<IEnumerable<TaskDto>> GetByNotAssignedByAsync(long accountId)
        {

            return await _context.TblTasks
                .Where(x => x.AssignedById != accountId && x.AdminAccountId == null && x.StatusId != 2)
                .Select(x => new TaskDto
                {
                    Id = x.Id,
                    TaskName = x.TaskName,
                    TaskDescription = x.TaskDescription,
                    AssignedToName = _context.Accounts
                        .Where(a => a.Id == x.AssignedToId)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    AssignedByName = _context.Accounts
                        .Where(a => a.Id == x.AssignedById)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    Status = StatusMapper.MapToStatus(x.StatusId),
                    CreatedAt = x.CreatedAt,
                    DueDate = x.TaskDeadline,
                }).ToListAsync();
        }

        public async Task<IEnumerable<TaskDto>> GetByAssignedToAsync(long accountId)
        {
            var assingedToName = await _context.Accounts
                .Where(a => a.Id == accountId)
                .Select(a => a.FullNameEn).FirstOrDefaultAsync();

            return await _context.TblTasks
                .Where(x => x.AssignedById != accountId && x.AdminAccountId == null && x.StatusId != 2)
                .Select(x => new TaskDto
                {
                    Id = x.Id,
                    TaskName = x.TaskName,
                    TaskDescription = x.TaskDescription,
                    AssignedToName = assingedToName,
                    AssignedByName = _context.Accounts
                        .Where(a => a.Id == x.AssignedById)
                        .Select(a => a.FullNameEn)
                        .FirstOrDefault(),
                    Status = StatusMapper.MapToStatus(x.StatusId),
                    CreatedAt = x.CreatedAt,
                    DueDate = x.TaskDeadline,
                }).ToListAsync();

            throw new NotImplementedException();
        }

        public void Add(TblTask task)
        {
            _context.TblTasks.Add(task);
        }

        public void Update(TblTask task)
        {
            _context.Update(task);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // -----------

        public void Remove(TblTask task)
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}
