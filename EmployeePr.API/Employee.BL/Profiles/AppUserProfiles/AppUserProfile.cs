using AutoMapper;
using EmployeePr.BL.DTOs.AppUserDTOs;
using EmployeePr.Core.Entities;

namespace EmployeePr.BL.Profiles.AppUserProfiles;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUserCreateDTO, AppUser>();
        CreateMap<AppUserCreateDTO, AppUser>().ReverseMap();
    }
}
