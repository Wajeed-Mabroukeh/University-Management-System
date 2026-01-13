using MyApiProject.Models;

namespace MyApiProject.Services;

public interface IStudentService
{
    Task RegisterStudentAsync(RegisterCourseDto dto);
}
