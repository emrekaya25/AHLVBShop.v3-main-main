using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.OfferDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public OfferController(IOfferService offerService,IUserService userService,IMapper mapper)
        {
            _offerService = offerService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("/AddOffer")]
        [ValidationFilter(typeof(OfferValidator))]
        public async Task<IActionResult> AddOffer(OfferDTORequest offerDTORequest)
        {
            Offer offer = _mapper.Map<Offer>(offerDTORequest);
            await _offerService.AddAsync(offer);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }

        [HttpPost("/RemoveOffer")]
        public async Task<IActionResult> RemoveOffer(Guid offerId)
        {
            Offer offer = await _offerService.GetAsync(x=>x.Id == offerId);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }
            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            await _offerService.RemoveAsync(offer);

            
            return Ok(Sonuc<bool> .SuccessWithData(true));
        }

        [HttpPost("/UpdateOffer")]
        [ValidationFilter(typeof(OfferValidator))]
        public async Task<IActionResult> UpdateOffer(OfferDTORequest offerDTORequest)
        {
            Offer offer = await _offerService.GetAsync(x => x.Id == offerDTORequest.Id);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }
            offer = _mapper.Map(offerDTORequest,offer);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc< OfferDTOResponse > .SuccessWithData(offerDTOResponse));
        }

        [HttpGet("/Offers")]
        public async Task<IActionResult> GetOffers()
        {
            var offers = await _offerService.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false,"User","Request");
            if (offers == null)
            {
                return NotFound(Sonuc<List<OfferDTOResponse>>.SuccessNoDataFound());
            }
            List<OfferDTOResponse> offerDTOResponseList = new();
            foreach (var offer in offers)
            {
                offerDTOResponseList.Add(_mapper.Map<OfferDTOResponse>(offer));
            }
            return Ok(Sonuc<List<OfferDTOResponse>>.SuccessWithData(offerDTOResponseList));
        }

        [HttpGet("/Offer/{offerId}")]
        public async Task<IActionResult> GetOffer(Guid offerId)
        {
            Offer offer = await _offerService.GetAsync(x=>x.Id == offerId);
            if (offer == null)
            {
                return NotFound(Sonuc<OfferDTOResponse>.SuccessNoDataFound());
            }
            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(offer);
            return Ok(Sonuc<OfferDTOResponse>.SuccessWithData(offerDTOResponse));
        }
    }
}
