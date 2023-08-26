using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Bed
{
    public int BedId { get; set; }

    public int? PatientCnic { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string Status { get; set; } = null!;

    public int? FeeAmount { get; set; }

    public virtual Patient? PatientCnicNavigation { get; set; }
}
