using CourseApi.Contracts;
using CourseApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _courseRep;
    public CoursesController(ICourseRepository courseRep)
    {
        _courseRep = courseRep;
    }

    [HttpGet]
    public async Task<IActionResult> GetCoursesAsync()
    {
        try
        {
            var courses = await _courseRep.GetCoursesAsync();

            if (!courses.Any())
                return NotFound("Courses not found.");

            return Ok(courses);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetCourseById")]
    public async Task<IActionResult> GetCourseAsync(int id)
    {
        try
        {
            var course = await _courseRep.GetCourseByIdAsync(id);

            if (course is null) return NotFound("Course not found.");

            return Ok(course);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}/multipleResult")]
    public async Task<IActionResult> GetCourseStudentsMultipleResultAsync(int id)
    {
        try
        {
            var course = await _courseRep.GetCourseStudentsMultipleResultsAsync(id);

            if (course is null) return NotFound("Course not found.");

            return Ok(course);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("multipleMapping")]
    public async Task<IActionResult> GetCourseStudentsMultipleMappingAsync()
    {
        try
        {
            var course = await _courseRep.GetCourseStudentsMultipleMappingAsync();

            return Ok(course);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourseAsync(CourseForCreationDTO course)
    {
        try
        {
            var createdCourse = await _courseRep.CreateCourseAsync(course);

            return CreatedAtRoute("GetCourseById", new { id = createdCourse.Id }, createdCourse);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseAsync(int id, CourseForUpdateDTO course)
    {
        try
        {
            var dbCourse = await _courseRep.GetCourseByIdAsync(id);

            if (dbCourse is null) return NotFound("Course not found.");

            await _courseRep.UpdateCourseAsync(id, course);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseAsync(int id)
    {
        try
        {
            var dbCourse = await _courseRep.GetCourseByIdAsync(id);

            if (dbCourse is null) return NotFound("Course not found.");

            await _courseRep.DeleteCourseAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
