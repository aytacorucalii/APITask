using AutoMapper;
using Final.Core.Entities;

namespace Final.BL.Profiles.ProductColorProfiles;

public class ProductColorProfile: Profile
{
    public ProductColorProfile()
    {
        CreateMap<ProductColorProfile, ProductColor> ().ReverseMap();
    }
}
