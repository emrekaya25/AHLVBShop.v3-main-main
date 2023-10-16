using AHLVBShop.Entity.DTO.BrandDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.BrandMapper
{
    public class BrandDTORequestMapper:Profile
    {
        public BrandDTORequestMapper()
        {
            CreateMap<Brand, BrandDTORequest>();
            CreateMap<BrandDTORequest, Brand>();
        }
    }
}
