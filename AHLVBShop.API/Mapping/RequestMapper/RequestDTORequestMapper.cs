using AHLVBShop.Entity.DTO.RequestDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.RequestMapper
{
    public class RequestDTORequestMapper:Profile
    {
        public RequestDTORequestMapper()
        {
            CreateMap<Request, RequestDTORequest>();
            CreateMap<RequestDTORequest, Request>();
        }
    }
}
