using employeePr.DAL.Repositories.Abstractions;
using employeePr.DAL.Repositories.Implementations;
using EmployeePr.BL.Services.Abstractions;
using EmployeePr.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeePr.BL.Configuration;

public static class ServicesConfiguration
{
    public static void AddBusinessConfiguration( this IServiceCollection Service)
    {
       Service.AddScoped<IEmployeeService, EmployeeService>();
       Service.AddScoped<IDepartmentService, DepartmentService>();
       Service.AddScoped<IAuthService, AuthService>();
    }
}
