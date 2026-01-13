using MyApiProject.DataBase;
using MyApiProject.Models;

namespace MyApiProject.Services;

public class CourseService : ICourseService
{
    private readonly UniversityManagementContext _context;

    public CourseService(UniversityManagementContext context)
    {
        _context = context;
    }

    public async Task CreateCourseClassAsync(CourseClassDto dto)
    {
        if (dto.Capacity <= 0)
            throw new Exception("Capacity must be a positive number.");

        bool conflict = await _context.CourseClasses.AnyAsync(c =>
            c.Days == dto.Days &&
            c.StartTime < dto.EndTime &&
            dto.StartTime < c.EndTime);

        if (conflict)
            throw new Exception("Schedule conflict detected.");

        var course = await _context.Courses
                         .FirstOrDefaultAsync(c => c.CourseName == dto.CourseName && c.MajorName == dto.MajorName)
                     ?? new Course { CourseName = dto.CourseName, MajorName = dto.MajorName };

        var courseClass = new CourseClass
        {
            Course = course,
            ClassName = dto.ClassName,
            Days = dto.Days,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            RoomNumber = dto.RoomNumber,
            Capacity = dto.Capacity
        };

        _context.CourseClasses.Add(courseClass);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CourseClass>> GetOpenCoursesByMajorAsync(string major)
    {
        return await _context.CourseClasses
            .Include(c => c.Course)
            .Include(c => c.Enrollments)
            .Where(c => c.Course.MajorName == major &&
                        c.Enrollments.Count < c.Capacity)
            .ToListAsync();
    }
}
