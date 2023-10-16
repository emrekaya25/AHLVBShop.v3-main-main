using AHLVBShop.Entity.DTO.CompanyDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.CompanyMapper
{
    public class CompanyDTORequestMapper:Profile
    {
        public CompanyDTORequestMapper()
        {
            CreateMap<Company, CompanyDTORequest>();
            CreateMap<CompanyDTORequest, Company>();
        }
    }
}

