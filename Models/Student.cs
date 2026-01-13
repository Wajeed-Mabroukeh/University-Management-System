using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? StudentNumber { get; set; }

    public string? Name { get; set; }

    public string? Major { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
