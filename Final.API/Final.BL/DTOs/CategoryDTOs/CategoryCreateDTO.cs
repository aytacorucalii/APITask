using Final.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Final.BL.DTOs.CategoryDTOs;

public class CategoryCreateDTO
{
    public string Name { get; set; }
    public IFormFile? Image { get; set; }
    public ICollection<Product>? Products { get; set; }

    public class CategoryCreateDTOValidation : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidation()
        {
            RuleFor(b => b.Name).NotEmpty()
            .WithMessage("Name cannot be empty")
            .NotNull().WithMessage("Name cannot be null")
            .MaximumLength(128).WithMessage("Maximum length is 128");

            RuleFor(pc => pc.Products)
            .Must(products => products == null || products.All(product => product != null))
            .WithMessage("Products cannot contain null values.");
        }
    }
}

//programcs erroru duzelt validator
//docker