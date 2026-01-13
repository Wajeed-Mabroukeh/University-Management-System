using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public string? MajorName { get; set; }

    public virtual ICollection<CourseClass> CourseClasses { get; } = new List<CourseClass>();
}
