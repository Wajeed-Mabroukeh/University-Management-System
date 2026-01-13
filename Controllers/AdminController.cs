using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using MyApiProject.Services;
using UniversityManagement.Services;

namespace MyApiProject.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ICourseService _courseService;

    public AdminController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost("course-class")]
    public async Task<IActionResult> CreateCourseClass(CourseClassDto dto)
    {
        try
        {
            await _courseService.CreateCourseClassAsync(dto);
            return Ok("Course class created successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
