using Microsoft.EntityFrameworkCore;
using MyApiProject.Models;
using MyApiProject.Services;
using UniversityManagement.Models;

namespace UniversityManagement.Services;

public class StudentService : IStudentService
{
    private readonly UniversityManagementSystemContext _context;

    public StudentService(UniversityManagementSystemContext context)
    {
        _context = context;
    }

    public async Task RegisterStudentAsync(RegisterCourseDto dto)
    {
        var student = await _context.Students.FindAsync(dto.StudentId)
                      ?? throw new Exception("Student not found.");

        var courseClass = await _context.CourseClasses
                              .Include(c => c.Enrollments)
                              .FirstOrDefaultAsync(c => c.Id == dto.CourseClassId)
                          ?? throw new Exception("Course class not found.");

        if (courseClass.Enrollments.Count >= courseClass.Capacity)
            throw new Exception("Class is full.");

        bool conflict = await _context.Enrollments
            .Include(e => e.CourseClass)
            .AnyAsync(e =>
                e.StudentId == dto.StudentId &&
                e.CourseClass.Days == courseClass.Days &&
                e.CourseClass.StartTime < courseClass.EndTime &&
                courseClass.StartTime < e.CourseClass.EndTime);

        if (conflict)
            throw new Exception("Schedule conflict with another class.");

        _context.Enrollments.Add(new Enrollment
        {
            StudentId = student.Id,
            CourseClassId = courseClass.Id
        });

        await _context.SaveChangesAsync();
    }
}
