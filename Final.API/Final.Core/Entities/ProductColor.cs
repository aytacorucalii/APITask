using Final.Core.Entities.Base;

namespace Final.Core.Entities;

public class ProductColor : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int ColorId { get; set; }
    public Color? Color { get; set; }
}
