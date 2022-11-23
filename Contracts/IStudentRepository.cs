using CourseApi.DTOs;
using CourseApi.Models;

namespace CourseApi.Contracts;
public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<Student> CreateStudentAsync(StudentForCreationDTO student);
    Task UpdateStudentAsync(int id, StudentForUpdateDTO student);
    Task DeleteStudentAsync(int id);
}
