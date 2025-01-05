using AutoMapper;
using Final.Core.Entities;

namespace Final.BL.Profiles.ProductColorProfiles;

public class ProductSizeProfile: Profile
{
    public ProductSizeProfile()
    {
        CreateMap<ProductSizeProfile, ProductSize>().ReverseMap();
    }
}
