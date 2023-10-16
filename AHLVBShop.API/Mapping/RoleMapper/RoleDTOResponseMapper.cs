using AHLVBShop.Entity.DTO.RoleDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.RoleMapper
{
    public class RoleDTOResponseMapper:Profile
    {
        public RoleDTOResponseMapper()
        {
            CreateMap<Role, RoleDTOResponse>();
            CreateMap<RoleDTOResponse, Role>();
        }
    }
}
