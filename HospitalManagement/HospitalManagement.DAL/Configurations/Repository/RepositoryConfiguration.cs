using HospitalManagement.DAL.Repositories.Abstractions;
using HospitalManagement.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.DAL.Configurations.Repository;

public static class RepositoryConfiguration
{
    public static void AddRepositoryConfiguration( this IServiceCollection Service)
    {
        Service.AddScoped<IPatientRepository, PatientRepository>();
        Service.AddScoped<IInsuranceRepository, InsuranceRepository>();
    }
}
