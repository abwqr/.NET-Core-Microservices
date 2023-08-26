using System;
using System.Collections.Generic;

namespace tutoroo.Models;

public partial class Employeerecord
{
    public int EmpId { get; set; }

    public DateOnly HireDate { get; set; }

    public float Salary { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Employee Emp { get; set; } = null!;
}
