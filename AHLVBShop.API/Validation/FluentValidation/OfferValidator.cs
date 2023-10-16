using AHLVBShop.Entity.DTO.OfferDTO;
using AHLVBShop.Entity.Poco;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class OfferValidator:AbstractValidator<OfferDTORequest>
    {
        public OfferValidator()
        {
            RuleFor(x=>x.OfferDescription).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("UserId boş olamaz.");
        }
    }
}
