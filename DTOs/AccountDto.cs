namespace Task_Tracker_V4.DTOs
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string RoleHash { get; set; } = null!;
        public DateOnly? JoinDate { get; set; }
    }
}
