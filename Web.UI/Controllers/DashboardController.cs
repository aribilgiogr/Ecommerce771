using CORE.Abstracts.IServices;
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
        // OnGet
        public IActionResult Categories(int? id = null)
        {
            var model = new CategoriesViewModel
            {
                Categories = service.GetCategories()
            };

            if (id != null)
            {
                model.SubCategories = service.GetSubCategories(id);
                model.NewSubCategory = new NewSubCategoryViewModel { ParentId = (int)id };
            }

            return View(model);
        }

        // OnPost
        [HttpPost]
        public async Task<IActionResult> Categories(CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.CreateCategoryAsync(model.NewCategoryName);
                if (reply.IsSuccess)
                {
                    return RedirectToAction();
                }
                if (reply.Errors != null)
                {
                    foreach (var err in reply.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err);
                    }
                }
            }
            model.Categories = service.GetCategories();
            return View(model);
        }
    }
}
