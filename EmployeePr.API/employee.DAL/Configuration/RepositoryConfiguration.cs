using employeePr.DAL.Repositories.Abstractions;
using employeePr.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace employeePr.DAL.Configuration;

public static class RepositoryConfiguration
{
    public static void AddRepositorConfiguration(this IServiceCollection Service)
    {
        Service.AddScoped<IEmployeeRepository, EmployeeRepository>();
        Service.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}
