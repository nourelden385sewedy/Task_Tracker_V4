using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Services;

namespace Task_Tracker_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound($"Task with this Id '{id}' Not Found");
            }
            return Ok(new {task});
        }


        [HttpGet("assigned-by/{id}")]
        public async Task<IActionResult> GetAllTasksAssignedBy(long id)
        {
            var tasks = await _taskService.GetAllTasksAssignedByIdAsync(id);
            if (tasks == null)
            {
                return NotFound($"There is no tasks assigned by this Id '{id}'");
            }
            return Ok(tasks);
        }


        [HttpGet("not-assigned-by/{id}")]
        public async Task<IActionResult> GetAllTasksNotAssignedBy(long id)
        {
            var tasks = await _taskService.GetAllTasksNotAssignedByIdAsync(id);
            if (tasks == null)
            {
                return NotFound($"There is no tasks");
            }
            return Ok(tasks);
        }


        [HttpGet("assigned-to/{id}")]
        public async Task<IActionResult> GetAllTasksAssignedTo(long id)
        {
            var tasks = await _taskService.GetAllTasksAssignedToIdAsync(id);
            if (tasks == null)
            {
                return NotFound($"There is no tasks assigned to this Id '{id}'");
            }
            return Ok(tasks);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateTask(TaskCreateDto taskDto)
        {
            bool isCreated = await _taskService.CreateTaskAsync(taskDto);
            if (!isCreated)
            {
                return BadRequest("There is problem, task didn't created");
            }
            return Ok("Task Created Successfully");
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTask(long id, TaskDto taskDto)
        {
            bool isUpdated = await _taskService.UpdateTaskAsync(id, taskDto);
            if (!isUpdated)
            {
                return NotFound($"Something went wrong, Can't Update '{taskDto.TaskName}' Task");
            }
            return Ok("Task Updated Successfully");
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            bool isDeleted = await _taskService.DeleteTaskAsync(id);
            if (!isDeleted)
            {
                return NotFound("Task Not Found, Can't delete it");
            }
            return Ok("Task Deleted successfully");
        }


        [HttpPatch("update-status/{id}")]
        public async Task<IActionResult> UpdateTaskStatus(long id)
        {
            bool isStatusUpdated = await _taskService.UpdateTaskStatusAsync(id);
            if (!isStatusUpdated)
            {
                return NotFound("Task Not Found, can't update Status");
            }
            return Ok("Task Status Updated Successfully");
        }
    }
}
