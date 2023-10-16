using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.CompanyDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("/AddCompany")]
        [ValidationFilter(typeof(CompanyValidator))]
        public async Task<IActionResult> AddCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = _mapper.Map<Company>(companyDTORequest);
            await _companyService.AddAsync(company);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        [HttpPost("/UpdateCompany")]
        [ValidationFilter(typeof(CompanyValidator))]
        public async Task<IActionResult> UpdateCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = await _companyService.GetAsync(x => x.Id == companyDTORequest.Id);
            company.CompanyName = companyDTORequest.CompanyName;
            company.Phone = companyDTORequest.Phone;
            company.Email = companyDTORequest.Email;
            company.Address = companyDTORequest.Address;
            //company = _mapper.Map(companyDTORequest, company);

            await _companyService.UpdateAsync(company);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        [HttpPost("/RemoveCompany/{companyId}")]
        public async Task<IActionResult> RemoveCompany(Guid companyId)
        {
            Company company = await _companyService.GetAsync(x => x.Id == companyId);
            await _companyService.RemoveAsync(company);
            // aktif-deaktif yapmak daha sağlıklı.
            return Ok(Sonuc<bool>.SuccessWithData(true));

        }

        [HttpGet("/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyService.GetAllAsync();
            if (companies == null)
            {
                return NotFound(Sonuc<List<CompanyDTOResponse>>.SuccessWithoutData());
            }
            else
            {
                List<CompanyDTOResponse> companyDTOResponseList = new();
                foreach (var companyDTO in companies)
                {
                    companyDTOResponseList.Add(_mapper.Map<CompanyDTOResponse>(companyDTO));
                }
                return Ok(Sonuc<List<CompanyDTOResponse>>.SuccessWithData(companyDTOResponseList));
            }
        }

        [HttpGet("/Company/{companyId}")]
        public async Task<IActionResult> GetCompany(Guid companyId)
        {
            var company = await _companyService.GetAsync(x => x.Id == companyId);
            if (company == null)
            {
                return NotFound(Sonuc<bool>.SuccessWithData(true));
            }
            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));

        }
    }
}
