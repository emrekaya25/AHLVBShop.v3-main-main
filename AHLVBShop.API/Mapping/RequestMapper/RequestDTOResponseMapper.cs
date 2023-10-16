using AHLVBShop.Entity.DTO.RequestDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.RequestMapper
{
    public class RequestDTOResponseMapper : Profile
    {
        public RequestDTOResponseMapper()
        {
            CreateMap<Request, RequestDTOResponse>().ForMember(dest => dest.EmployeeName, opt =>
            {
                opt.MapFrom(src => src.Employee.EmployeeFirstName + " " + src.Employee.EmployeeLastName);
            }).
            ForMember(dest => dest.ProductName, opt =>
            {
                opt.MapFrom(src => src.Product.ProductName);
            });

            CreateMap<RequestDTOResponse, Request>();
        }
    }
}
