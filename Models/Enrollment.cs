using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseClassId { get; set; }

    public virtual CourseClass CourseClass { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
