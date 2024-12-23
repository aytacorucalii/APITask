using employeePr.DAL.Configuration;
using EmployeePr.BL.Configuration;
using EmployeePr.BL.DTOs.DepartmentDTOs;
using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.BL.Profiles.DepartmentProfiles;
using EmployeePr.Core.Entities;
using EmployeePr.DAL.DAL;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessConfiguration();
builder.Services.AddRepositorConfiguration();

builder.Services.AddAutoMapper(typeof(DepartmentProfile));
builder.Services.AddValidatorsFromAssembly(typeof(CreateEmployeeValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateDepartmentDTOValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddControllers();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    {
        opt.Password.RequiredLength = 8;
        opt.User.RequireUniqueEmail = true;
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789._";
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        opt.Lockout.MaxFailedAccessAttempts = 3;
    }
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);

var app = builder.Build();
app.UseAuthentication();

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
