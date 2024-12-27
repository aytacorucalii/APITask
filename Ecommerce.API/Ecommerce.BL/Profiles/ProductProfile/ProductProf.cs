using AutoMapper;
using Ecommerce.BL.DTOs.ProductDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Profiles.ProductProfile;

public class ProductProf : Profile 
{
    public ProductProf()
    {
        CreateMap<ProductCreateDto, Product>().ReverseMap();

    }
}
