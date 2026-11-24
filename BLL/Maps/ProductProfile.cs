using AutoMapper;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;

namespace BLL.Maps
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
           

            // DTO -> Entity
            CreateMap<NewProductDto, Product>();

            // Entity -> DTO
            CreateMap<Product, ProductListItemDto>()
                .ForCtorParam("BrandName", opt => opt.MapFrom(src => src.Brand.Name))
                .ForCtorParam("CategoryName", opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForCtorParam("SubCategoryName", opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForCtorParam("ModelName", opt => opt.MapFrom(src => src.Model.Name))
                .ForCtorParam("CommentCount", opt => opt.MapFrom(src => src.Comments.Count))
                .ForCtorParam("Rating", opt => opt.MapFrom(src => src.Comments.Any() ? src.Comments.Average(c => c.Rating) : 0));
        }
    }
}
