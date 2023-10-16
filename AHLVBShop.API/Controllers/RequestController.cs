using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.RequestDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public RequestController(IRequestService requestService, IMapper mapper, IEmployeeService employeeService)
        {
            _requestService = requestService;
            _mapper = mapper;
            _employeeService = employeeService;

        }

        [HttpPost("/AddRequest")]
        [ValidationFilter(typeof(RequestValidator))]
        public async Task<IActionResult> AddRequest(RequestDTORequest requestDTORequest)
        {
            Request request = _mapper.Map<Request>(requestDTORequest);
            await _requestService.AddAsync(request);

            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);
            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));
        }
        [HttpPost("/RemoveRequest/{requestId}")]
        public async Task<IActionResult> RemoveRequest(Guid requestId)
        {
            Request request = await _requestService.GetAsync(x => x.Id == requestId);
            if (request == null)
            {
                return NotFound(Sonuc<bool>.SuccessNoDataFound());
            }
            await _requestService.RemoveAsync(request);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/UpdateRequest")]
        [ValidationFilter(typeof(RequestValidator))]
        public async Task<IActionResult> UpdateRequest(RequestDTORequest requestDTORequest)
        {
            Request request = await _requestService.GetAsync(x => x.Id == requestDTORequest.Id);
            if (request == null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());
            }
            //request.RequestTitle = requestDTORequest.RequestTitle;

            request = _mapper.Map(requestDTORequest, request);

            await _requestService.UpdateAsync(request);

            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(request);
            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData( requestDTOResponse));
        }

        [HttpGet("/GetRequests")]
        public async Task<IActionResult> GetRequests()
        {
            var requests = await _requestService.GetAllAsync(x => x.IsActive == true && x.IsDeleted == false, "Employee","Product");
            if (requests == null)
            {
                return NotFound(Sonuc<List<RequestDTOResponse>>.SuccessNoDataFound());
            }
            List<RequestDTOResponse> RequestDTOResponseList = new();
            foreach (var request in requests)
            {
                RequestDTOResponseList.Add(_mapper.Map<RequestDTOResponse>(request));
            }
            return Ok(Sonuc<List<RequestDTOResponse>>.SuccessWithData(RequestDTOResponseList));
        }

        [HttpGet("/GetRequest/{requestId}")]
        public async Task<IActionResult> GetRequest(Guid requestId)
        {
            Request Request = await _requestService.GetAsync(x=>x.Id == requestId);
            if (Request == null)
            {
                return NotFound(Sonuc<RequestDTOResponse>.SuccessNoDataFound());
            }
            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(Request);
            return Ok(Sonuc<RequestDTOResponse>.SuccessWithData(requestDTOResponse));
        }
    }
}
