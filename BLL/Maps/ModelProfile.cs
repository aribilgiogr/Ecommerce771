using AutoMapper;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;

namespace BLL.Maps
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            // DTO -> Entity, Entity -> DTO
            CreateMap<ModelDto, Model>().ReverseMap();
        }
    }
}
