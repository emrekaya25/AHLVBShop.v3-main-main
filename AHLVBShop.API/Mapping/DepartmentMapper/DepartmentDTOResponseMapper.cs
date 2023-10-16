using AHLVBShop.Entity.DTO.DepartmentDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.DepartmentMapper
{
    public class DepartmentDTOResponseMapper:Profile
    {
        public DepartmentDTOResponseMapper()
        {
            CreateMap<Department, DepartmentDTOResponse>().
                ForMember(dest => dest.CompanyName, opt =>
                {
                    opt.MapFrom(src => src.Company.CompanyName);
                });
            CreateMap<DepartmentDTOResponse, Department>();
        }
    }
}
