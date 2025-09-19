using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Services
{
    public class TaskService
    {

        private readonly ITaskRepository _taskRepo;
        private readonly IAccountRepository _accountRepo;
        public TaskService(ITaskRepository taskRepo, IAccountRepository accountRepo)
        {
            _taskRepo = taskRepo;
            _accountRepo = accountRepo;
        }


        public async Task<TaskDto?> GetTaskByIdAsync(long id)
        {
            return await _taskRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            return await _taskRepo.GetAllAsync();
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAssignedByIdAsync(long id)
        {
            return await _taskRepo.GetByAssignedByIdAsync(id);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksNotAssignedByIdAsync(long id)
        {
            return await _taskRepo.GetByNotAssignedByAsync(id);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAssignedToIdAsync(long id)
        {
            return await _taskRepo.GetByAssignedToAsync(id);
        }
        
        public async Task<bool> CreateTaskAsync(TaskDto taskDto)
        {
            TblTask task = new TblTask()
            {
                TaskName = taskDto.TaskName,
                TaskDescription = taskDto.TaskDescription,
                AssignedToId = await _accountRepo.GetIdByNameAsync(taskDto.AssignedToName),
                AssignedById = await _accountRepo.GetIdByNameAsync(taskDto.AssignedByName),
                StatusId = StatusMapper.MapToStatusID(taskDto.Status)
            };

            _taskRepo.Add(task);
            await _taskRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTaskAsync(long id, TaskDto taskDto)
        {
            var task = await _taskRepo.GetFullTaskByIdAsync(id);

            if (task != null)
            {
                task.TaskName = taskDto.TaskName;
                task.TaskDescription = taskDto.TaskDescription;
                task.AssignedToId = await _accountRepo.GetIdByNameAsync(taskDto.AssignedToName);
                task.TaskDeadline = taskDto.DueDate;
                task.StatusId = StatusMapper.MapToStatusID(taskDto.Status);

                _taskRepo.Update(task);
                await _taskRepo.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteTaskAsync(long id)
        {
            var task = await _taskRepo.GetFullTaskByIdAsync(id);

            if (task != null )
            {
                task.StatusId = 2;
                _taskRepo.Update(task);
                await _taskRepo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateTaskStatusAsync(long id)
        {
            var task = await _taskRepo.GetFullTaskByIdAsync(id);

            if (task != null)
            {
                task.StatusId++;
                _taskRepo.Update(task);
                await _taskRepo.SaveChangesAsync();
                return true;
            }


            return false;
        }

    }
}
