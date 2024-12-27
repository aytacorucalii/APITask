using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.BL.DTOs.ProductDTO;

namespace Ecommerce.BL.Profiles.OrderItemProfile;

public class OrderItemProf : Profile
{
    public OrderItemProf()
    {
        CreateMap<OrderItemCreateDto, OrderItem>(). ReverseMap();
      
    }
}
