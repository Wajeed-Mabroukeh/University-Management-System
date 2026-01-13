namespace MyApiProject.Models;

public class Student
{
    public int Id { get; set; }
    public string StudentNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Major { get; set; } = null!;
}
