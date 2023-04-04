using CourseApi.Contracts;
using CourseApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRep;
    public StudentsController(IStudentRepository studentRep)
    {
        _studentRep = studentRep;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync()
    {
        try
        {
            var students = await _studentRep.GetStudentsAsync();

            if (!students.Any())
                return NotFound("Students not found.");

            return Ok(students);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetStudentById")]
    public async Task<IActionResult> GetStudentAsync(int id)
    {
        try
        {
            var student = await _studentRep.GetStudentByIdAsync(id);

            if (student is null) return NotFound("Student not found.");

            return Ok(student);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudentAsync(StudentForCreationDTO student)
    {
        try
        {
            var createdStudent = await _studentRep.CreateStudentAsync(student);

            return CreatedAtRoute("GetStudentById", new { id = createdStudent.RA }, createdStudent);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudentAsync(int id, StudentForUpdateDTO student)
    {
        try
        {
            var dbStudent = await _studentRep.GetStudentByIdAsync(id);

            if (dbStudent is null) return NotFound("Student not found.");

            await _studentRep.UpdateStudentAsync(id, student);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentAsync(int id)
    {
        try
        {
            var dbStudent = await _studentRep.GetStudentByIdAsync(id);

            if (dbStudent is null) return NotFound("Student not found.");

            await _studentRep.DeleteStudentAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
