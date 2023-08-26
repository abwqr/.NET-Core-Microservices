using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientCnic { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public int DoctorId { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public string Status { get; set; } = null!;

    public int FeeAmount { get; set; }

    public virtual Employee Doctor { get; set; } = null!;

    public virtual Patient PatientCnicNavigation { get; set; } = null!;
}
