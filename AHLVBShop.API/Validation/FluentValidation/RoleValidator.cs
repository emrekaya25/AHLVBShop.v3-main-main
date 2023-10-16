using AHLVBShop.Entity.DTO.RoleDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class RoleValidator:AbstractValidator<RoleDTORequest>
    {
        public RoleValidator()
        {
            RuleFor(x=>x.RoleName).NotEmpty().WithMessage("Rol ismi boş olamaz.");
        }
    }
}
