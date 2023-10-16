using AHLVBShop.Entity.DTO.UserDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.UserMapper
{
    public class UserDTORequestMapper:Profile
    {
        public UserDTORequestMapper()
        {
            CreateMap<User, UserDTORequest>();
            CreateMap<UserDTORequest, User>();
        }
    }
}
