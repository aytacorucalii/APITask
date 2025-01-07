using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.BL.Configurations;

public static class ServicesConfiguration
{
    public static void AddServicesConfiguration(this IServiceCollection Service )
    {
        Service.AddScoped<IInsureService, InsureService>();
        Service.AddScoped<IPatientService, PatientService>();
    }
}
