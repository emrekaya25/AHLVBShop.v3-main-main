using AHLVBShop.Entity.DTO.ProductDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.ProductMapper
{
    public class ProductDTORequestMapper:Profile
    {
        public ProductDTORequestMapper()
        {
            CreateMap<ProductDTORequest, Product>();
            CreateMap<Product, ProductDTORequest>();
            //.
            //    ForMember(dest => dest.CategoryName, opt =>
            //{
            //    opt.MapFrom(src => src.Category.CategoryName);
            //}).
            //ForMember(dest => dest.BrandName, opt =>
            //{
            //    opt.MapFrom(src => src.Brand.BrandName);
            //});
        }
    }
}
