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
                .ForCtorParam("ListPrice", opt => opt.MapFrom(src => src.Price * (decimal)(1 + src.TaxRate / 100)))
                .ForCtorParam("DiscountedPrice", opt => opt.MapFrom(src => src.Price * (decimal)((1 - src.DiscountRate / 100) * (1 + src.TaxRate / 100))))
                .ForCtorParam("BrandName", opt => opt.MapFrom(src => src.Brand.Name))
                .ForCtorParam("CategoryName", opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForCtorParam("SubCategoryName", opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForCtorParam("ModelName", opt => opt.MapFrom(src => src.Model.Name))
                .ForCtorParam("CommentCount", opt => opt.MapFrom(src => src.Comments.Count))
                .ForCtorParam("Rating", opt => opt.MapFrom(src => src.Comments.Any() ? (int)src.Comments.Average(c => c.Rating) : 0))
                .ForCtorParam("CoverImageUrl", opt => opt.MapFrom(src => src.Images.Any() ? src.Images.FirstOrDefault()!.ImageUrl : null))
                .ForCtorParam("CategoryId", opt => opt.MapFrom(src => src.SubCategory.CategoryId));
        }
    }
}
