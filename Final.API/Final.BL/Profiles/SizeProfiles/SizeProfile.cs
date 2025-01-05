using AutoMapper;
using Final.BL.DTOs.SizeDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles.SizeProfiles;

public class SizeProfile:Profile
{
    public SizeProfile()
    {
        CreateMap<SizeCreateDTO, Size>().ReverseMap();
    }
}
