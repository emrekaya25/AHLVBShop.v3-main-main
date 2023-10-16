using AHLVBShop.Entity.DTO.ProductDTO;
using FluentValidation;

namespace AHLVBShop.API.Validation.FluentValidation
{
    public class ProductValidator:AbstractValidator<ProductDTORequest>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz.");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş olamaz.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x=>x.Quantity).NotEmpty().WithMessage("Stok bilgisi boş olamaz.");
            RuleFor(x=>x.BrandId).NotEmpty().WithMessage("BrandId boş olamaz.");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("CategoryId boş olamaz.");
        }
    }
}
