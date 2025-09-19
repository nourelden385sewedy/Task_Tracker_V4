using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Services;

namespace Task_Tracker_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;
        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet("user-nots/{id}")]
        public async Task<IActionResult> GetAllNotificationsByAccountId(long id)
        {
            return Ok();
        }


        [HttpPatch("notification/{id}")]
        public async Task<IActionResult> UpdateNotificationStatus(long id)
        {
            bool isUpdated = await _notificationService.ChangeNotificationStatus(id);
            if (!isUpdated)
            {
                return NotFound("Notification Not Found, can't update the Status");
            }
            return Ok("Notification Now is Read");
        }

    }
}
