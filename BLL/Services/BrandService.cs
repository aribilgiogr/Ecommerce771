using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using CORE.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Reply> CreateBrandAsync(string name, string? logoUrl)
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brand = new Brand { Name = name, LogoUrl = logoUrl };
            await repo.InsertOneAsync(brand);
            return await unitOfWork.CommitAsync();
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            var repo = unitOfWork.GetRepository<Brand>();
            var brands = repo.Query();
            return brands.Select(b => new BrandDto(b.Id, b.Name, b.LogoUrl));
        }
    }
}
