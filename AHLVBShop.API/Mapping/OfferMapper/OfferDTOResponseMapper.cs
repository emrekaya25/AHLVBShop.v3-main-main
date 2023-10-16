using AHLVBShop.Entity.DTO.OfferDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.OfferMapper
{
    public class OfferDTOResponseMapper:Profile
    {
        public OfferDTOResponseMapper()
        {
            CreateMap<Offer, OfferDTOResponse>().
                ForMember(dest => dest.UserName, opt =>
                {
                    opt.MapFrom(src => src.User.UserName);
                }).
                ForMember(dest => dest.RequestName, opt =>
                {
                    opt.MapFrom(src => src.Request.RequestTitle);
                }).ReverseMap();
            
        }
    }
}
