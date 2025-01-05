using Final.Core.Entities;

namespace Final.BL.DTOs.ProductDTOs;

public class ProductEditDTO
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? CategoryId { get; set; }
    public ICollection<ProductColor>? ProductColors { get; set; }
    public ICollection<ProductSize>? ProductSizes { get; set; }
}
