using AHLVBShop.Entity.DTO.UserDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.UserMapper
{
    public class UserDTOResponseMapper : Profile
    {
        public UserDTOResponseMapper()
        {
            CreateMap<UserDTOResponse, User>();
            CreateMap<User, UserDTOResponse>().
    ForMember(dest => dest.RoleId, opt =>
    {
        opt.MapFrom(src => src.RoleId);
    }).
    ForMember(dest => dest.RoleName, opt =>
    {
        opt.MapFrom(src => src.Role.RoleName);
    });
        }
    }
}
