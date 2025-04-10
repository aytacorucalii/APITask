﻿using Ecommerce.Core.Entities.Base;

namespace Ecommerce.Core.Entities;

public class OrderItem : BaseAuditable
{
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
