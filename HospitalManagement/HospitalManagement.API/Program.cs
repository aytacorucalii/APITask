using HospitalManagement.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.DAL.Configurations.Repository;
using HospitalManagement.BL.Configurations;
using FluentValidation;
using HospitalManagement.BL.Profiles;
using static HospitalManagement.BL.DTOs.PatientDTOs.PatientCreateDTO;
using System.Reflection;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRepositoryConfiguration();
builder.Services.AddServicesConfiguration();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(PatientProfile));
builder.Services.AddAutoMapper(typeof(InsuranceProfile));
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(InsureCreateDTOValidation).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});
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
