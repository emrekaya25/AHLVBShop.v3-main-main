using AHLVBShop.Entity.DTO.EmployeeDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.EmployeeMapper
{
    public class EmployeeDTOResponseMapper:Profile
    {
        public EmployeeDTOResponseMapper()
        {
            CreateMap<Employee, EmployeeDTOResponse>().
                ForMember(dest => dest.DepartmentName, opt =>
                {
                    opt.MapFrom(src => src.Department.DepartmentName);
                }).
                ForMember(dest => dest.RoleName, opt =>
                {
                    opt.MapFrom(src => src.Role.RoleName);
                }).
                ForMember(dest => dest.CompanyName, opt =>
                {
                    opt.MapFrom(src => src.Company.CompanyName);
                }).ReverseMap();
        }
    }
}
