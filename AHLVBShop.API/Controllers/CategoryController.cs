using AHLVBShop.API.Aspects;
using AHLVBShop.API.Validation.FluentValidation;
using AHLVBShop.Business.Abstract;
using AHLVBShop.Entity.DTO.CategoryDTO;
using AHLVBShop.Entity.Poco;
using AHLVBShop.Entity.Result;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AHLVBShop.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> AddCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = _mapper.Map<Category>(categoryDTORequest);
            await _categoryService.AddAsync(category);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));

        }
        [HttpPost("/RemoveCategory/{categoryId}")]
        public async Task<IActionResult> RemoveCategory(Guid categoryId)
        {
            Category category = await _categoryService.GetAsync(x=>x.Id == categoryId);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessWithoutData());
            }
            await _categoryService.RemoveAsync(category);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/UpdateCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> UpdateCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = await _categoryService.GetAsync(x=>x.Id ==categoryDTORequest.Id);
            if(category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessWithoutData());
            }
            //category.CategoryName = categoryDTORequest.CategoryName;
            category = _mapper.Map(categoryDTORequest, category);
            await _categoryService.UpdateAsync(category);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }

        [HttpGet("/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories == null)
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessWithoutData());
            }
            List<CategoryDTOResponse> categoryDTOResponseList = new();
            foreach (var category in categories)
            {
                categoryDTOResponseList.Add(_mapper.Map<CategoryDTOResponse>(category));
            }
            return Ok(Sonuc<List<CategoryDTOResponse>>.SuccessWithData(categoryDTOResponseList));
        }

        [HttpGet("/Category/{categoryId}")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            Category category = await _categoryService.GetAsync(x=>x.Id == categoryId);
            if (category == null) 
            {
                return NotFound();
            }
            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }
    }
}
