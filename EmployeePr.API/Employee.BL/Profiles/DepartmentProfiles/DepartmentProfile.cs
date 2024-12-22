using AutoMapper;
using EmployeePr.BL.DTOs.DepartmentDTOs;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Profiles.DepartmentProfiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<CreateDepartmentDTO, Department>();
        CreateMap<CreateDepartmentDTO, Department>().ReverseMap();
    }
}
