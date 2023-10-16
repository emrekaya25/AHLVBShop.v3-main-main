using AHLVBShop.Entity.DTO.LoginDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginDTORequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı adı kısmı boş olamaz.");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Sifre boş olamaz.");
        }
    }
}
