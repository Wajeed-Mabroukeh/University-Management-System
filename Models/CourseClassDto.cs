namespace MyApiProject.Models;

public class CourseClassDto
{
    public string CourseName { get; set; } = null!;
    public string MajorName { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string Days { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string RoomNumber { get; set; } = null!;
    public int Capacity { get; set; }
}
