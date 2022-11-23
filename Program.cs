using CourseApi.Context;
using CourseApi.Contracts;
using CourseApi.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSingleton<DapperContext>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<ICourseRepository, CourseRepository>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}