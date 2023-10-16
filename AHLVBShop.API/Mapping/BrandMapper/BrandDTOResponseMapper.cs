using AHLVBShop.Entity.DTO.BrandDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.BrandMapper
{
    public class BrandDTOResponseMapper:Profile
    {
        public BrandDTOResponseMapper()
        {
            CreateMap<Brand, BrandDTOResponse>();
            CreateMap<BrandDTOResponse, Brand>();

        }
    }
}
