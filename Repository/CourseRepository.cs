using System.Data;
using CourseApi.Context;
using CourseApi.DTOs;
using CourseApi.Models;
using Dapper;

namespace CourseApi.Repository;
public class CourseRepository
{
    private readonly DapperContext _context;
    public CourseRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        var query = @"SELECT 
                            Id, Nome, Categoria, OferecidoPor, Descricao, Turno, CargaHoraria, Observacao, EOnline
                        FROM 
                            Courses 
                        WHERE 
                            Id = @Id";

        var connection = _context.CreateConnection();

        var course = await connection.QuerySingleOrDefaultAsync<Course>(query, new { id });

        return course;
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        var query = @"SELECT 
                            Id, Nome, Categoria, OferecidoPor, Descricao, Turno, CargaHoraria, Observacao, EOnline
                        FROM 
                            Courses";

        var connection = _context.CreateConnection();

        var courses = await connection.QueryAsync<Course>(query);

        return courses.ToList();
    }

    public async Task<Course> CreateCourseAsync(CourseForCreationDTO course)
    {
        var query = @"INSERT INTO Courses(
                            Nome, Categoria, OferecidoPor, Descricao, Turno, CargaHoraria, Observacao, EOnline)
                        VALUES(
                            @nome, @categ, @oferecPor, @descr, @turno, @cargaHor, @obs, @eOnline);
                        
                        SELECT CAST(SCOPE_IDENTITY() AS int);";

        var connection = _context.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("nome", course.Nome, DbType.String);
        parameters.Add("categ", course.Categoria, DbType.String);
        parameters.Add("oferecPor", course.OferecidoPor, DbType.String);
        parameters.Add("descr", course.Descricao, DbType.String);
        parameters.Add("turno", course.Turno, DbType.String);
        parameters.Add("cargaHor", course.CargaHoraria, DbType.Int16);
        parameters.Add("obs", course.Observacao, DbType.String);
        parameters.Add("eOnline", course.EOnline, DbType.Boolean);

        var id = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);

        var createdCourse = new Course
        {
            Id = id,
            Nome = course.Nome,
            Categoria = course.Categoria,
            OferecidoPor = course.OferecidoPor,
            Descricao = course.Descricao,
            Turno = course.Turno,
            CargaHoraria = course.CargaHoraria,
            Observacao = course.Observacao,
            EOnline = course.EOnline
        };

        return createdCourse;
    }

    public async Task UpdateCourseAsync(int id, CourseForUpdateDTO course)
    {
        var query = @"UPDATE 
                            Courses 
                        SET 
                            Turno = @turno, CargaHoraria = @cargHor, Observacao = @obs, EOnline = eOnline
                        WHERE 
                            Id = @Id";

        var connection = _context.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("turno", course.Turno, DbType.String);
        parameters.Add("cargHor", course.CargaHoraria, DbType.Int16);
        parameters.Add("obs", course.Observacao, DbType.String);
        parameters.Add("eOnline", course.EOnline, DbType.Boolean);

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteCourseAsync(int id)
    {
        var query = @"DELETE FROM 
                            Courses
                        WHERE 
                            Id = @Id";

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<Course> GetCourseStudentsMultipleResultsAsync(int id)
    {
        var query = @"SELECT Id, Nome, Categoria, OferecidoPor, Descricao, Turno, CargaHoraria, Observacao, EOnline
                    FROM Courses 
                    WHERE Id = @Id;
                    
                    SELECT RA, Nome, Idade, Endereco, Telefone, CursoId
                    FROM Students
                    WHERE CursoId = @Id;";

        var connection = _context.CreateConnection();

        using var multi = await connection.QueryMultipleAsync(query, new { id });

        var course = await multi.ReadSingleOrDefaultAsync<Course>();
        if (course != null)
            course.Students = (await multi.ReadAsync<Student>()).ToList();

        return course;
    }

    public async Task<List<Course>> GetCourseStudentsMultipleMappingAsync()
    {
        var query = @"SELECT 
                            Id, c.Nome, Categoria, OferecidoPor, Descricao, Turno, CargaHoraria, Observacao, EOnline,
                            RA, s.Nome, Idade, Endereco, Telefone, CursoId
                        FROM 
                            Courses c
                        JOIN 
                            Students s
                        ON 
                            c.Id = s.CursoId";

        var connection = _context.CreateConnection();

        var courseDic = new Dictionary<int, Course>();

        var courses = await connection.QueryAsync<Course, Student, Course>(
            query,
            (course, student) =>
            {
                if (!courseDic.TryGetValue(course.Id, out var currentCourse))
                {
                    currentCourse = course;
                    courseDic.Add(currentCourse.Id, currentCourse);
                }

                currentCourse.Students.Add(student);
                return currentCourse;
            },
            splitOn: "RA");

        return courses.Distinct().ToList();
    }
}