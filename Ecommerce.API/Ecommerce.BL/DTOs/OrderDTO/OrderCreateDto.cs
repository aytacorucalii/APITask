using Ecommerce.Core.Entities;

namespace Ecommerce.BL.DTOs.OrderDTO;

public class OrderCreateDto
{
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
    public decimal TotalPrice { get; set; }
}
