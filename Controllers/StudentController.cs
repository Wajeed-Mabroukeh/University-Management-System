using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using MyApiProject.Services;

namespace MyApiProject.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IStudentService _studentService;

    public StudentController(ICourseService courseService, IStudentService studentService)
    {
        _courseService = courseService;
        _studentService = studentService;
    }

    [HttpGet("courses/{major}")]
    public async Task<IActionResult> GetCourses(string major)
    {
        var courses = await _courseService.GetOpenCoursesByMajorAsync(major);
        return Ok(courses);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCourseDto dto)
    {
        try
        {
            await _studentService.RegisterStudentAsync(dto);
            return Ok("Registration successful.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
