using AutoMapper;
using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using CORE.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Reply> CreateBrandAsync(BrandDto model)
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brand = mapper.Map<Brand>(model);
            await repo.InsertOneAsync(brand);
            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> DeleteBrandAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brand = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (brand != null)
            {
                repo.DeleteOne(brand);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Marka bulunamadı!");
        }

        public BrandDto? GetBrand(int id)
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brand = repo.Query().FirstOrDefault(x => x.Id == id);
            return mapper.Map<BrandDto>(brand);
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brands = repo.Query().ToList();
            return mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<Reply> UpdateBrandAsync(BrandDto model)
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brand = await repo.Query().FirstOrDefaultAsync(x => x.Id == model.Id);
            if (brand != null)
            {
                brand.Name = model.Name;
                brand.LogoUrl = model.LogoUrl;
                repo.UpdateOne(brand);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Marka bulunamadı!");
        }
    }
}
