using AHLVBShop.Entity.DTO.CompanyDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.CompanyMapper
{
    public class CompanyDTOResponseMapper:Profile
    {
        public CompanyDTOResponseMapper()
        {
            CreateMap<Company, CompanyDTOResponse>();
            CreateMap<CompanyDTOResponse, Company>();
        }
    }
}
