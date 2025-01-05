using Final.Core.Entities;
using FluentValidation;

namespace Final.BL.DTOs.ProductColorDTOs;

public class ProductColorCreateDTO
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int ColorId { get; set; }
    public Color? Color { get; set; }
    public class ProductColorCreateDTOValidation : AbstractValidator<ProductColorCreateDTO>
    {
        public ProductColorCreateDTOValidation()
        {
            RuleFor(pcc => pcc.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

            RuleFor(pcc => pcc.Product)
                .Must(product => product == null || product != null)
                .WithMessage("Product cannot be null if provided.");

            RuleFor(pcc => pcc.ColorId)
                .GreaterThan(0).WithMessage("ColorId must be greater than zero.");

            RuleFor(pcc => pcc.Color)
                .Must(color => color == null || color != null)
                .WithMessage("Color cannot be null if provided.");
        }
    }
}