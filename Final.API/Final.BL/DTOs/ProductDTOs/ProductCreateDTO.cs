using Final.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Final.BL.DTOs.ProductDTOs;

public class ProductCreateDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? Image { get; set; }
    public ICollection<ProductColor>? ProductColors { get; set; }
    public ICollection<ProductSize>? ProductSizes { get; set; }
    public class ProductCreateDtoValidation : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDtoValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(128).WithMessage("Name cannot exceed 128 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

   
            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than zero.");

            RuleFor(p => p.ProductColors)
                .Must(colors => colors == null || colors.All(color => color != null))
                .WithMessage("ProductColors cannot contain null values.");

            RuleFor(p => p.ProductSizes)
                .Must(sizes => sizes == null || sizes.All(size => size != null))
                .WithMessage("ProductSizes cannot contain null values.");
        }
    }
}
