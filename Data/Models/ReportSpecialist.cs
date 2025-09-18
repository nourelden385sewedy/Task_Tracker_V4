using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Models;

public partial class ReportSpecialist
{
    public int Id { get; set; }

    public DateTime DateReport { get; set; }

    public string StudentName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string SpecialistSignature { get; set; } = null!;

    public long StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;
}
