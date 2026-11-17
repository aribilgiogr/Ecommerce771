using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using CORE.Utils;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Reply> CreateCategoryAsync(string name)
        {
            var repo = unitOfWork.GetRepository<Category>();

            await repo.InsertOneAsync(new Category { Name = name });

            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> CreateSubCategoryAsync(int parentId, string name)
        {
            var repo = unitOfWork.GetRepository<SubCategory>();

            await repo.InsertOneAsync(new SubCategory { Name = name, CategoryId = parentId });

            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> DeleteCategoryAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Category>();

            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                repo.DeleteOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kategori bulunamadı!");
        }

        public async Task<Reply> DeleteSubCategoryAsync(int id)
        {
            var repo = unitOfWork.GetRepository<SubCategory>();

            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                repo.DeleteOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kategori bulunamadı!");
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var repo = unitOfWork.GetRepository<Category>();

            var categories = repo.Query();
            return categories.Select(x => new CategoryDto(x.Id, x.Name)).ToList();
        }

        public IEnumerable<SubCategoryDto> GetSubCategories(int? parentId = null)
        {
            var repo = unitOfWork.GetRepository<SubCategory>();

            var categories = repo.Query();
            if (parentId != null)
            {
                categories = categories.Where(x => x.CategoryId == parentId);
            }

            return categories.Include(x => x.Category) // JOIN Categories
                             .Select(x => new SubCategoryDto(x.Id, x.Name, x.CategoryId, x.Category.Name))
                             .ToList();
        }

        public async Task<Reply> RenameCategoryAsync(int id, string newName)
        {
            var repo = unitOfWork.GetRepository<Category>();
            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                category.Name = newName;
                repo.UpdateOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kategori bulunamadı!");
        }

        public async Task<Reply> RenameSubCategoryAsync(int id, string newName)
        {
            var repo = unitOfWork.GetRepository<SubCategory>();
            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                category.Name = newName;
                repo.UpdateOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kategori bulunamadı!");
        }
    }
}
