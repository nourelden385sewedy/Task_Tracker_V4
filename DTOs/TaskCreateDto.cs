namespace Task_Tracker_V4.DTOs
{
    public class TaskCreateDto
    {
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public string? AssignedToName { get; set; }
        public string? AssignedByName { get; set; }
        public string? Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
