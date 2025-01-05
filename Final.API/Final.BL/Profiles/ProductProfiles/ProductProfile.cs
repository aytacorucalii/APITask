using AutoMapper;
using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;

namespace Final.BL.Profiles.ProductProfiles;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDTO, Product>().ReverseMap();
    }
}
