using AHLVBShop.Entity.DTO.CategoryDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.CategoryMapper
{
    public class CategoryDTOResponseMapper:Profile
    {
        public CategoryDTOResponseMapper()
        {
            CreateMap<Category, CategoryDTOResponse>();
            CreateMap<CategoryDTOResponse, Category>();
        }
    }
}
