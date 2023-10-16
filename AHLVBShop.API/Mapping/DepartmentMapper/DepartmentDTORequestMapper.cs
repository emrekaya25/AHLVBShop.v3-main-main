using AHLVBShop.Entity.DTO.DepartmentDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.DepartmentMapper
{
    public class DepartmentDTORequestMapper:Profile
    {
        public DepartmentDTORequestMapper()
        {
            
            CreateMap<DepartmentDTORequest, Department>();
            CreateMap<Department, DepartmentDTORequest>();
                //.ForMember(dest => dest.CompanyName, opt =>
                //{
                //    opt.MapFrom(src => src.Company.CompanyName);
                //});
        }
    }
}
