using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Models;

public partial class AttendanceRecord
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public DateTime Date { get; set; }

    public int SessionNumber { get; set; }

    public bool IsPresent { get; set; }

    public long? NoteId { get; set; }

    public virtual ICollection<BehaviorNote> BehaviorNotes { get; set; } = new List<BehaviorNote>();

    public virtual BehaviorNote? Note { get; set; }

    public virtual Account Student { get; set; } = null!;
}
