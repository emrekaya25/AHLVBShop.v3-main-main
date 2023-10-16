using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.CategoryDTO;
using AHLVBShop.Entity.DTO.ProductDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper, ICategoryService categoryService, IBrandService brandService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        [HttpPost("/AddProduct")]
        [ValidationFilter(typeof(ProductValidator))]
        public async Task<IActionResult> AddProduct(ProductDTORequest productDTORequest)
        {
            Product product = _mapper.Map<Product>(productDTORequest);
            await _productService.AddAsync(product);

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);
            return Ok(Sonuc<ProductDTOResponse>.SuccessWithData(productDTOResponse));
        }

        [HttpPost("/RemoveProduct/{productId}")]
        public async Task<IActionResult> RemoveProduct(Guid productId)
        {
            Product product = await _productService.GetAsync(x=>x.Id == productId);
            if (product == null)
            {
                return NotFound(Sonuc<ProductDTOResponse>.SuccessNoDataFound());
            }
            await _productService.RemoveAsync(product);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
        [HttpPost("/UpdateProduct")]
        [ValidationFilter(typeof(ProductValidator))]
        public async Task<IActionResult> UpdateProduct(ProductDTORequest productDTORequest)
        {
            Product product = await _productService.GetAsync(x=>x.Id == productDTORequest.Id);
            if(product == null)
            {
                return NotFound(Sonuc<ProductDTOResponse>.SuccessNoDataFound());
            }

            product= _mapper.Map(productDTORequest,product );
            
            await _productService.UpdateAsync(product);
            
            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);
            return Ok(Sonuc<ProductDTOResponse>.SuccessWithData(productDTOResponse));
        }

        [HttpGet("/Products")]
        [ProducesResponseType(typeof(List<CategoryDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync(x=>x.IsActive==true && x.IsDeleted==false,"Category","Brand");
            if (products == null)
            {
                return NotFound(Sonuc<ProductDTOResponse>.SuccessNoDataFound());
            }
            List<ProductDTOResponse> productDTOResponseList = new();
            foreach (var product in products)
            {
                productDTOResponseList.Add(_mapper.Map<ProductDTOResponse>(product));
            }
            return Ok(Sonuc<List<ProductDTOResponse>>.SuccessWithData(productDTOResponseList));
        }

        [HttpGet("/Product/{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            Product product = await _productService.GetAsync(x=>x.Id==productId);
            if (product == null)
            {
                return NotFound(Sonuc<ProductDTOResponse>.SuccessNoDataFound());
            }
            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);
            return Ok(Sonuc<ProductDTOResponse>.SuccessWithData(productDTOResponse));
        }
    }
}
