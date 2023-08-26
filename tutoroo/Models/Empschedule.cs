using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Empschedule
{
    public int EmpId { get; set; }

    public DateOnly? ShiftDate { get; set; }

    public string? Room { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
