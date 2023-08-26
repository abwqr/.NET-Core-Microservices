using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Patient
{
    public int PatientCnic { get; set; }

    public string PatientPhoneNumber { get; set; } = null!;

    public string PatientFirstName { get; set; } = null!;

    public string PatientLastName { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Bed> Beds { get; set; } = new List<Bed>();
}
