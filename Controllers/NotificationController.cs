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
            var nots = await _notificationService.GetNotificationsByAccountIdAsync(id);
            if (nots == null)
            {
                return NotFound("There isn't any Notifications Right Now!!");
            }
            return Ok(nots);
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
