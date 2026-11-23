using AutoMapper;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;

namespace BLL.Maps
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<NewProductDto, Product>();
        }
    }
}
