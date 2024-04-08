using Microsoft.EntityFrameworkCore;
using StudentMarks.Context;
using StudentMarks.Filter;
using StudentMarks.Mapper;
using StudentMarks.Repositery.StudentRepositery;
using StudentMarks.Repositery;
using StudentMarks.Repositery.SubjectRepositery;
using StudentMarks.Repositery.ReportRepositery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("custom", o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region configure Db
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));
#endregion

builder.Services.AddControllers(c => c.Filters.Add(new ExceptionFilter()));
builder.Services.AddAutoMapper(typeof(StudentMapper));
builder.Services.AddTransient<IStudentRepositery, StudentRepositery>();
builder.Services.AddTransient<ISubjectRepositery, SubjectRepositery>();
builder.Services.AddTransient<IReportRepositery, ReportRepositery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("custom");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
