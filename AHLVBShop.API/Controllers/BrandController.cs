using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.BrandDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]

    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService,IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpPost("/AddBrand")]
        [ValidationFilter(typeof(BrandValidator))]
        public async Task<IActionResult> AddBrand(BrandDTORequest brandDTORequest)
        {
            Brand brand = _mapper.Map<Brand>(brandDTORequest);
            await _brandService.AddAsync(brand);

            BrandDTOResponse brandDTOResponse = _mapper.Map<BrandDTOResponse>(brand);
            return Ok(Sonuc<BrandDTOResponse>.SuccessWithData(brandDTOResponse));
        }

        [HttpPost("/RemoveBrand/{brandId}")]
        public async Task<IActionResult> RemoveBrand(Guid brandId)
        {
            Brand brand = await _brandService.GetAsync(x=>x.Id == brandId);
            if (brand == null)
            {
                return NotFound();
            }

            //brand.IsActive = false;
            //brand.IsDeleted = true;                   aslında silme işlemi böyle yapılmalı verileri silmek sıkıntı
            //await _brandService.UpdateAsync(brand);
          

            await _brandService.RemoveAsync(brand);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/UpdateBrand")]
        [ValidationFilter(typeof(BrandValidator))]
        public async Task<IActionResult> UpdateBrand(BrandDTORequest brandDTORequest)
        {
            Brand brand = await _brandService.GetAsync(x=>x.Id ==brandDTORequest.Id);
            if (brand == null)
            {
                return NotFound();
            }
            //brand.BrandName = brandDTORequest.BrandName;
            brand = _mapper.Map(brandDTORequest, brand);
            await _brandService.UpdateAsync(brand);

            BrandDTOResponse brandDTOResponse = _mapper.Map<BrandDTOResponse>(brand);
            return Ok(Sonuc<BrandDTOResponse>.SuccessWithData(brandDTOResponse));
        }

        [HttpGet("/Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _brandService.GetAllAsync();
            if (brands == null)
            {
                return NotFound();
            }
            List<BrandDTOResponse> brandDTOResponseList = new();
            foreach (var brand in brands)
            {
                brandDTOResponseList.Add(_mapper.Map<BrandDTOResponse>(brand));
            }
            return Ok(Sonuc<List<BrandDTOResponse>>.SuccessWithData(brandDTOResponseList));
        }

        [HttpGet("/Brand/{brandId}")]
        public async Task<IActionResult> GetBrand(Guid brandId)
        {
            Brand brand = await _brandService.GetAsync(x=>x.Id == brandId);
            if (brand == null)
            {
                return NotFound();
            }
            BrandDTOResponse brandDTOResponse = _mapper.Map<BrandDTOResponse>(brand);
            return Ok(Sonuc<BrandDTOResponse>.SuccessWithData(brandDTOResponse));
        }
    }
}
