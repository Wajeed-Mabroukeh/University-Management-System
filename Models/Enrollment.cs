namespace MyApiProject.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseClassId { get; set; }
    public CourseClass CourseClass { get; set; } = null!;
}