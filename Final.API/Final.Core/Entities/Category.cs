using Final.Core.Entities.Base;

namespace Final.Core.Entities;

public class Category: BaseAuditable
{
    public string Name { get; set; }
    public string? Image { get; set; }
    public ICollection<Product>? Products { get; set; }
}
