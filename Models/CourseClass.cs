namespace MyApiProject.Models;

public class CourseClass
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public string ClassName { get; set; } = null!;
    public string Days { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string RoomNumber { get; set; } = null!;
    public int Capacity { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
