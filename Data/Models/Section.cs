using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Models;

public partial class Section
{
    public long Id { get; set; }

    public string SectionName { get; set; } = null!;
}
