using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Employeerecord? Employeerecord { get; set; }

    public virtual Empschedule? Empschedule { get; set; }
}
