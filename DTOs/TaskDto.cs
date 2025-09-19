namespace Task_Tracker_V4.DTOs
{
    public class TaskDto
    {
        public long Id { get; set; }
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public string? AssignedToName { get; set; }
        public string? AssignedByName { get; set; }
        public string? Status { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
