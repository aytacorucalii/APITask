using AutoMapper;
using EmployeePr.BL.DTOs.EmployeeDTOs;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Profiles.EmployeeProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDTO,Employee>();
        CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
    }
}
