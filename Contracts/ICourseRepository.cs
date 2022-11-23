using CourseApi.DTOs;
using CourseApi.Models;

namespace CourseApi.Contracts;
public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> GetCourseByIdAsync(int id);
    Task<Course> CreateCourseAsync(CourseForCreationDTO course);
    Task UpdateCourseAsync(int id, CourseForUpdateDTO course);
    Task DeleteCourseAsync(int id);
    Task<Course> GetCourseStudentsMultipleResultsAsync(int id);
    Task<List<Course>> GetCourseStudentsMultipleMappingAsync();
}
