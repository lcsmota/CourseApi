using System.Data;
using CourseApi.Context;
using CourseApi.DTOs;
using CourseApi.Models;
using Dapper;

namespace CourseApi.Repository;

public class StudentRepository
{
    private readonly DapperContext _context;
    public StudentRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        var query = @"SELECT 
                        RA, Nome, Idade, Endereco, Telefone, CursoId
                    FROM
                        Students
                    WHERE 
                        RA = @Id";

        var connection = _context.CreateConnection();

        var student = await connection.QuerySingleOrDefaultAsync<Student>(query, new { id });

        return student;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        var query = @"SELECT
                        RA, Nome, Idade, Endereco, Telefone, CursoId
                    FROM
                        Students";

        var connection = _context.CreateConnection();

        var students = await connection.QueryAsync<Student>(query);

        return students.ToList();
    }

    public async Task<Student> CreateStudentAsync(StudentForCreationDTO student)
    {
        var query = @"INSERT INTO Students(
                        Nome, Idade, Endereco, Telefone, CursoId)
                    VALUES(
                        @nome, @idade, @ender, @tel, @cursoId);
                    
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

        var connection = _context.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("nome", student.Nome, DbType.String);
        parameters.Add("idade", student.Idade, DbType.Int16);
        parameters.Add("ender", student.Endereco, DbType.String);
        parameters.Add("tel", student.Telefone, DbType.String);
        parameters.Add("cursoId", student.CursoId, DbType.Int32);

        var ra = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);

        var createdStudent = new Student
        {
            RA = ra,
            Nome = student.Nome,
            Idade = student.Idade,
            Endereco = student.Endereco,
            Telefone = student.Telefone,
            CursoId = student.CursoId
        };

        return createdStudent;
    }
    public async Task UpdateStudentAsync(int id, StudentForUpdateDTO student)
    {
        var query = @"UPDATE 
                        Students
                    SET 
                        Nome = @nome, Idade = @idade, Endereco = @ender, Telefone = @tel
                    WHERE 
                        RA = @Id";

        var connection = _context.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("nome", student.Nome, DbType.String);
        parameters.Add("idade", student.Idade, DbType.Int16);
        parameters.Add("ender", student.Endereco, DbType.String);
        parameters.Add("tel", student.Telefone, DbType.String);

        await connection.ExecuteAsync(query, parameters);
    }
    public async Task DeleteStudentAsync(int id)
    {
        var query = @"DELETE FROM 
                        Students
                    WHERE 
                        RA = @Id";

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }
}
