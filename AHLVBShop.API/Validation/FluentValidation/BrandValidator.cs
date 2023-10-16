using AHLVBShop.Entity.DTO.BrandDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class BrandValidator:AbstractValidator<BrandDTORequest>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka ismi boş olamaz.");
        }
    }
}
