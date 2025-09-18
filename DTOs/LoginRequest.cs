using System.ComponentModel.DataAnnotations;

namespace Task_Tracker_V4.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
