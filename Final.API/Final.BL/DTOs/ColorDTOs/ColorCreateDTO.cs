using Final.Core.Entities;
using FluentValidation;

namespace Final.BL.DTOs.ColorDTOs;

public class ColorCreateDTO
{
    public string Name { get; set; }
    public ICollection<ProductColor>? ProductColors { get; set; }
    public class ColorCreateDTOValidation : AbstractValidator<ColorCreateDTO>
    {
        public ColorCreateDTOValidation()
        {
            RuleFor(b => b.Name).NotEmpty()
            .WithMessage("Name cannot be empty")
            .NotNull().WithMessage("Name cannot be null")
            .MaximumLength(128).WithMessage("Maximum length is 128");

            RuleFor(p => p.ProductColors)
             .Must(colors => colors == null || colors.All(color => color != null))
             .WithMessage("ProductColors cannot contain null values.");
        }
    }
}