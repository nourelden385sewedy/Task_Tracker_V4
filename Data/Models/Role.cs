using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Data.Models;

public partial class Role
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public int? OrderNo { get; set; }

    public string? BusinessEntity { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
