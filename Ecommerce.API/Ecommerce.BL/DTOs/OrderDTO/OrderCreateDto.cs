using Ecommerce.Core.Entities;
using FluentValidation;

namespace Ecommerce.BL.DTOs.OrderDTO;

public class OrderCreateDto
{
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
    public decimal TotalPrice { get; set; }
}
public class OrderCreateValidator : AbstractValidator<Order>
{
    public OrderCreateValidator()
    {
       
    }
}