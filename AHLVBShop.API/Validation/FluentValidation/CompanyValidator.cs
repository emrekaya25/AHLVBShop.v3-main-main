using AHLVBShop.Entity.DTO.CompanyDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class CompanyValidator:AbstractValidator<CompanyDTORequest>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket ismi boş olamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş olamaz.");
        }
    }
}
