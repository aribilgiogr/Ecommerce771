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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Reply> CreateProductAsync(NewProductDto newProduct)
        {
            var repo = unitOfWork.GetRepository<Product>();

            var product = mapper.Map<Product>(newProduct);

            await repo.InsertOneAsync(product);
            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> DeleteProductAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Product>();
            var product = await repo.Query().FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                repo.DeleteOne(product);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Ürün bulunamadı!");
        }

        public IEnumerable<ProductListItemDto> GetProducts()
        {
            var repo = unitOfWork.GetRepository<Product>();
            var products = repo.Query()
                               .Include(p => p.SubCategory)
                               .ThenInclude(s => s.Category)
                               .Include(p => p.Model)
                               .Include(p => p.Brand)
                               .Include(p => p.Comments)
                               .Include(p => p.Images)
                               .ToList();

            return mapper.Map<IEnumerable<ProductListItemDto>>(products);
        }
    }
}
