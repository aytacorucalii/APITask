using AutoMapper;
using Final.BL.DTOs.CategoryDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles.CategoryProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
    }
}
