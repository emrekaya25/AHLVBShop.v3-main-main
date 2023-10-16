using AHLVBShop.Entity.DTO.DepartmentDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class DepartmentValidator:AbstractValidator<DepartmentDTORequest>
    {
        public DepartmentValidator()
        {
            RuleFor(x=>x.DepartmentName).NotEmpty().WithMessage("Departman ismi boş olamaz.");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("E-posta boş olamaz.");
            RuleFor(x=>x.CompanyId).NotEmpty().WithMessage("Şirket Id kısmı boş olamaz.");
        }
    }
}
