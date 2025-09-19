using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Services;

namespace Task_Tracker_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost("LoginAuth")]
        public async Task<IActionResult> LoginAuth(LoginRequest req)
        {
            var account = await _loginService.ValidateLoginAsync(req);

            if (account == null) return NotFound(new
            {
                message = "User Not Found with this Email," +
                "Check the Password or the Email Again"
            });

            return Ok(account);
        }
    }
}
