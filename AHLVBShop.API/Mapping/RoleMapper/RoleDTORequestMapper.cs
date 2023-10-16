using AHLVBShop.Entity.DTO.RoleDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.RoleMapper
{
    public class RoleDTORequestMapper:Profile
    {
        public RoleDTORequestMapper()
        {
            CreateMap<Role, RoleDTORequest>();
            CreateMap<RoleDTORequest, Role>();
        }
    }
}
