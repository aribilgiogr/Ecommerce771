using CORE.Concretes.DTOs;
using CORE.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Abstracts.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductListItemDto> GetProducts();
        Task<Reply> CreateProductAsync(NewProductDto newProduct);
        Task<Reply> DeleteProductAsync(int id);
    }
}
