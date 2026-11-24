using AutoMapper;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Maps
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            // DTO -> Entity, Entity -> DTO
            CreateMap<BrandDto, Brand>().ReverseMap();
        }
    }
}
