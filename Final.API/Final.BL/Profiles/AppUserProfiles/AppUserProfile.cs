using AutoMapper;
using Final.BL.DTOs.AppUserDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles.AppUserProfiles;

public class AppUserProfile: Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUserCreateDTO, AppUser>();

    }
}
