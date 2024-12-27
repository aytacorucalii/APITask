using AutoMapper;
using Ecommerce.BL.DTOs.OrderDTO;
using Ecommerce.BL.DTOs.OrderItemDTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.BL.Profiles.OrderProfile;

public class OrderProf : Profile
{
    public OrderProf()
    {
        CreateMap<OrderCreateDto, Order>().ReverseMap();
    }
}
