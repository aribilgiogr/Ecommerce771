using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        private ICategoryService service;
        public DashboardController(ICategoryService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories(int? id = null)
        {
            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories()
            };
            if (id != null)
            {
                model.SubCategories = service.GetSubCategories(id);
                model.SelectedCategory = service.GetCategories().FirstOrDefault(x => x.Id == id);
                model.NewSubCategory = new NewSubCategoryViewModel { ParentId = (int)id };
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([Bind(Prefix = "NewCategory")] NewCategoryViewModel formData)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.CreateCategoryAsync(formData.Name);

                if (reply.IsSuccess)
                {
                    return RedirectToAction("Categories");
                }

                foreach (var err in reply.Errors ?? [])
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }

            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories()
            };

            return View("Categories", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory([Bind(Prefix = "NewSubCategory")] NewSubCategoryViewModel formData)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.CreateSubCategoryAsync(formData.ParentId, formData.Name);

                if (reply.IsSuccess)
                {
                    return RedirectToAction("Categories", new { id = formData.ParentId });
                }

                foreach (var err in reply.Errors ?? [])
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }

            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories(),
                SubCategories = service.GetSubCategories(formData.ParentId),
                SelectedCategory = service.GetCategories().FirstOrDefault(x => x.Id == formData.ParentId),
                NewSubCategory = formData
            };
            return View("Categories", model);
        }

        [HttpPost]
        public async Task<IActionResult> RenameCategory([Bind(Prefix = "SelectedCategory")] CategoryDto formData)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.RenameCategoryAsync(formData.Id, formData.Name);

                if (reply.IsSuccess)
                {
                    return RedirectToAction("Categories");
                }

                foreach (var err in reply.Errors ?? [])
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }

            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories(),
                SubCategories = service.GetSubCategories(formData.Id),
                SelectedCategory = service.GetCategories().FirstOrDefault(x => x.Id == formData.Id),
                NewSubCategory = new NewSubCategoryViewModel { ParentId = formData.Id }
            };
            return View("Categories", model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var reply = await service.DeleteCategoryAsync(id);
            if (reply.IsSuccess)
            {
                return RedirectToAction("Categories");
            }

            foreach (var err in reply.Errors ?? [])
            {
                ModelState.AddModelError(string.Empty, err);
            }

            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories(),
                SubCategories = service.GetSubCategories(id),
                SelectedCategory = service.GetCategories().FirstOrDefault(x => x.Id == id),
                NewSubCategory = new NewSubCategoryViewModel { ParentId = id }
            };
            return View("Categories", model);
        }
    }
}
