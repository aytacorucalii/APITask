using Final.BL.DTOs.ProductColorDTOs;
using Final.Core.Entities;
using FluentValidation;

namespace Final.BL.DTOs.ProductSizeDTOs;

public class ProductSizeCreateDTO
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int SizeId { get; set; }
    public Size? Size { get; set; }
    public class ProductSizeCreateDTOValidation : AbstractValidator<ProductSizeCreateDTO>
    {
        public ProductSizeCreateDTOValidation()
        {
            RuleFor(pcc => pcc.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

          
            RuleFor(pcc => pcc.Product)
                .Must(product => product == null || product != null)
                .WithMessage("Product cannot be null if provided.");

            RuleFor(pcc => pcc.SizeId)
                .GreaterThan(0).WithMessage("ColorId must be greater than zero.");

            RuleFor(pcc => pcc.Size)
                .Must(color => color == null || color != null)
                .WithMessage("Color cannot be null if provided.");
        }
    }
}
