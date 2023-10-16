using AHLVBShop.Entity.DTO.EmployeeDTO;
using AHLVBShop.Entity.Poco;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class EmployeeValidator:AbstractValidator<EmployeeDTORequest>
    {
        public EmployeeValidator()
        {
            RuleFor(x=>x.EmployeeFirstName).NotEmpty().WithMessage("Ad boş olamaz.");
            RuleFor(x=>x.EmployeeLastName).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x=>x.EmployeeUserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x=>x.EmployeePassword).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("E-posta boş olamaz");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(x=>x.RoleId).NotEmpty().WithMessage("RoleId boş olamaz.");
            RuleFor(x=>x.DepartmentId).NotEmpty().WithMessage("DepartmentId boş olamaz.");
        }
    }
}
