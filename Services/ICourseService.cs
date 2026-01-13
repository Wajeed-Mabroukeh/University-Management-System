using MyApiProject.Models;
using UniversityManagement.Models;

namespace MyApiProject.Services;

public interface ICourseService
{
    Task CreateCourseClassAsync(CourseClassDto dto);
    Task<List<CourseClass>> GetOpenCoursesByMajorAsync(string major);
}
