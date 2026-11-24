using CORE.Concretes.DTOs;
using CORE.Utils;

namespace CORE.Abstracts.IServices
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetBrands();
        BrandDto? GetBrand(int id);
        Task<Reply> CreateBrandAsync(BrandDto model);
        Task<Reply> UpdateBrandAsync(BrandDto model);
        Task<Reply> DeleteBrandAsync(int id);

    }
}
