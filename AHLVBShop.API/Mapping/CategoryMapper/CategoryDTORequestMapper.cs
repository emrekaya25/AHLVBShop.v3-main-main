using AHLVBShop.Entity.DTO.CategoryDTO;
using AHLVBShop.Entity.Poco;
using AutoMapper;

namespace AHLVBShop.API.Mapping.CategoryMapper
{
    public class CategoryDTORequestMapper:Profile
    {
        public CategoryDTORequestMapper()
        {
            CreateMap<Category, CategoryDTORequest>();
            CreateMap<CategoryDTORequest, Category>();
        }
    }
}
