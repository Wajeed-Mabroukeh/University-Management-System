using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class CourseClass
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string? ClassName { get; set; }

    public string? Days { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string? RoomNumber { get; set; }

    public int Capacity { get; set; }

    public string? CourseName { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
