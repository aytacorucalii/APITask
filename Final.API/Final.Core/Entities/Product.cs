using Final.Core.Entities.Base;

namespace Final.Core.Entities;

public class Product: BaseAuditable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<ProductColor>? ProductColors { get; set; }
    public ICollection<ProductSize>? ProductSizes { get; set; }
}
