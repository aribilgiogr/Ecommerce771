using CORE.Concretes.DTOs;
using CORE.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Abstracts.IServices
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetBrands();
        Task<Reply> CreateBrandAsync(string name, string? logoUrl);
    }
}
