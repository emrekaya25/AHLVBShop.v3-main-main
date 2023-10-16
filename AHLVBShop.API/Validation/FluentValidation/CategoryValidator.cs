using AHLVBShop.Entity.DTO.CategoryDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class CategoryValidator:AbstractValidator<CategoryDTORequest>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Olamaz.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adı Uzunluğu 50 karakterden fazla olamaz.");
        }
    }
}
