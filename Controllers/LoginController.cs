using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker_V4.DTOs;

namespace Task_Tracker_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {




        [HttpPost("LoginAuth")]
        public async Task<IActionResult> LoginAuth(LoginRequest req)
        {

            return Ok();
        }
    }
}
