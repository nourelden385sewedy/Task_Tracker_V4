using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Data.Models;

public partial class ReviewerSupervisorExtension
{
    public long AccountId { get; set; }

    public long? AssignedClassId { get; set; }

    public long StatusId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual TblClass? AssignedClass { get; set; }

    public virtual Status Status { get; set; } = null!;
}
