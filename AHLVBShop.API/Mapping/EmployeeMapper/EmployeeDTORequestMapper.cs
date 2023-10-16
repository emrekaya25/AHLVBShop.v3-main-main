using AHLVBShop.Entity.DTO.EmployeeDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.EmployeeMapper
{
    public class EmployeeDTORequestMapper:Profile
    {
        public EmployeeDTORequestMapper()
        {
            CreateMap<Employee, EmployeeDTORequest>();
                
                //.ForMember(dest => dest.DepartmentName, opt =>
                //{
                //    opt.MapFrom(src => src.Department.DepartmentName);
                //}).
                //ForMember(dest => dest.RoleName, opt =>
                //{
                //    opt.MapFrom(src => src.Role.RoleName);
                //});
            CreateMap<EmployeeDTORequest, Employee>();
        }
    }
}
