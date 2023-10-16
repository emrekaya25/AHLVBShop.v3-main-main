using AHLVBShop.Entity.DTO.RequestDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class RequestValidator:AbstractValidator<RequestDTORequest>
    {
        public RequestValidator()
        {
            RuleFor(x => x.RequestTitle).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("EmployeeId boş bırakılamaz.");
        }
    }
}
