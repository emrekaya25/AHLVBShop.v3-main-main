using AHLVBShop.Entity.DTO.UserDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class UserValidator:AbstractValidator<UserDTORequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserFirstName).NotEmpty().WithMessage("İsim boş olamaz");
            RuleFor(x => x.UserLastName).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta boş olamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz");
        }
    }
}
