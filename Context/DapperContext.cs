using System.Data;
using Microsoft.Data.SqlClient;

namespace CourseApi.Context;
public class DapperContext
{
    private readonly IConfiguration _configuration;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("Default"));
}
