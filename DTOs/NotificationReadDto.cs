namespace Task_Tracker_V4.DTOs
{
    public class NotificationReadDto
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? ReadStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
