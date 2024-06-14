using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.ConnectionModels.Data;
using StudentManagement.ConnectionModels.Data;
using StudentManagement.DAL.Repositories.IRepository;
using StudentManagement.DAL.Repositories.Repository;
using StudentManagement.Services.Services.IService;
using StudentManagement.Services.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<ConnectionDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs"),
    b => b.MigrationsAssembly("StudentManagement3Tier")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
