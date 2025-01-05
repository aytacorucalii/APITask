using AutoMapper;
using Final.BL.DTOs.ColorDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles.ColorProfiles;

public class ColorProfile : Profile
{
    public ColorProfile()
    {
        CreateMap<ColorCreateDTO, Color>().ReverseMap();
    }
}
