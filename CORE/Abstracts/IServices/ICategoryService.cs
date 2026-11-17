using CORE.Concretes.DTOs;
using CORE.Utils;

namespace CORE.Abstracts.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        IEnumerable<SubCategoryDto> GetSubCategories(int? parentId = null);

        Task<Reply> CreateCategoryAsync(string name);
        Task<Reply> CreateSubCategoryAsync(int parentId, string name);

        Task<Reply> DeleteCategoryAsync(int id);
        Task<Reply> DeleteSubCategoryAsync(int id);

        Task<Reply> RenameCategoryAsync(int id, string newName);
        Task<Reply> RenameSubCategoryAsync(int id, string newName);
    }
}
