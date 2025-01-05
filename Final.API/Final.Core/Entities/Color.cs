using Final.Core.Entities.Base;

namespace Final.Core.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; }
    public ICollection<ProductColor>? ProductColors { get; set; }
}
