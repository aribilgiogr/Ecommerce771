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

        public async Task<EditProductDto?> GetProductForEditAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Product>();
            var product = await repo.Query().FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                return mapper.Map<EditProductDto>(product);
            }
            return null;
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

        public async Task<Reply> UpdateProductAsync(int id, EditProductDto updatedProduct)
        {
            var repo = unitOfWork.GetRepository<Product>();
            var product = await repo.Query().FirstOrDefaultAsync(p => p.Id == id);
            if (product != null && updatedProduct.Id == product.Id)
            {
                product.Title = updatedProduct.Title;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.DiscountRate = updatedProduct.DiscountRate;
                product.TaxRate = updatedProduct.TaxRate;
                product.BrandId = updatedProduct.BrandId;
                product.SubCategoryId = updatedProduct.SubCategoryId;
                product.ModelId = updatedProduct.ModelId;
                product.Stock = updatedProduct.Stock;
                product.Active = updatedProduct.Active;

                repo.UpdateOne(product);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Ürün bulunamadı!");
        }
    }
}
