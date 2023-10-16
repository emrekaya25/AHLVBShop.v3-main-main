using AHLVBShop.Entity.DTO.OfferDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.OfferMapper
{
    public class OfferDTORequestMapper:Profile
    {
        public OfferDTORequestMapper()
        {
            CreateMap<Offer,OfferDTORequest>();
            CreateMap<OfferDTORequest, Offer>();
        }
    }
}
