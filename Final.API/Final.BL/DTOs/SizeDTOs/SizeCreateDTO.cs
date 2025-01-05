using Final.BL.DTOs.ColorDTOs;
using Final.Core.Entities;
using FluentValidation;

namespace Final.BL.DTOs.SizeDTOs;

public class SizeCreateDTO
{
    public string Name { get; set; }
    public ICollection<ProductSize>? ProductSizes { get; set; }

    public class SizeCreateDTOValidation : AbstractValidator<SizeCreateDTO>
    {
        public SizeCreateDTOValidation()
        {
            RuleFor(b => b.Name).NotEmpty()
            .WithMessage("Name cannot be empty")
            .NotNull().WithMessage("Name cannot be null")
            .MaximumLength(128).WithMessage("Maximum length is 128");

            RuleFor(p => p.ProductSizes)
             .Must(s => s == null || s.All(s => s != null))
             .WithMessage("ProductColors cannot contain null values.");
        }
    }
}
