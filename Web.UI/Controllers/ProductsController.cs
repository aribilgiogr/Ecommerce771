using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService service;
        private readonly IBrandService brandService;
        private readonly IModelService modelService;
        private readonly ICategoryService categoryService;
        public ProductsController(IProductService service, IBrandService brandService, IModelService modelService, ICategoryService categoryService)
        {
            this.service = service;
            this.brandService = brandService;
            this.modelService = modelService;
            this.categoryService = categoryService;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(service.GetProducts());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.Brands = new SelectList(brandService.GetBrands(), "Id", "Name");
            ViewBag.Models = new SelectList(modelService.GetModels(), "Id", "Name");
            ViewBag.Categories = new SelectList(categoryService.GetSubCategories(), "Id", "Name", null, "ParentName");
            ViewBag.TaxRates = new SelectList(new double[] { 0, 1, 10, 20 });
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewProductDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.CreateProductAsync(model);
                if (reply.IsSuccess)
                {
                    return RedirectToAction("index");
                }
                if (reply.Errors != null)
                {
                    foreach (var err in reply.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err);
                    }
                }
            }
            ViewBag.Brands = new SelectList(brandService.GetBrands(), "Id", "Name", model.BrandId);
            ViewBag.Models = new SelectList(modelService.GetModels(), "Id", "Name", model.ModelId);
            ViewBag.Categories = new SelectList(categoryService.GetSubCategories(), "Id", "Name", model.SubCategoryId, "ParentName");
            ViewBag.TaxRates = new SelectList(new double[] { 0, 1, 10, 20 }, model.TaxRate);
            return View(model);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await service.GetProductForEditAsync(id);
            if (model != null)
            {
                ViewBag.Brands = new SelectList(brandService.GetBrands(), "Id", "Name", model.BrandId);
                ViewBag.Models = new SelectList(modelService.GetModels(), "Id", "Name", model.ModelId);
                ViewBag.Categories = new SelectList(categoryService.GetSubCategories(), "Id", "Name", model.SubCategoryId, "ParentName");
                ViewBag.TaxRates = new SelectList(new double[] { 0, 1, 10, 20 }, model.TaxRate);
                return View(model);
            }
            return NotFound();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditProductDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.UpdateProductAsync(id, model);
                if (reply.IsSuccess)
                {
                    return RedirectToAction("index");
                }
                if (reply.Errors != null)
                {
                    foreach (var err in reply.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err);
                    }
                }
            }
            ViewBag.Brands = new SelectList(brandService.GetBrands(), "Id", "Name", model.BrandId);
            ViewBag.Models = new SelectList(modelService.GetModels(), "Id", "Name", model.ModelId);
            ViewBag.Categories = new SelectList(categoryService.GetSubCategories(), "Id", "Name", model.SubCategoryId, "ParentName");
            ViewBag.TaxRates = new SelectList(new double[] { 0, 1, 10, 20 }, model.TaxRate);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var reply = await service.DeleteProductAsync(id);
            if (reply.IsSuccess)
            {
                return RedirectToAction("index");
            }
            string errors = reply.Errors != null ? string.Join(", ", reply.Errors) : "";
            return Problem(errors);
        }

        public IActionResult AddImage(int id)
        {
            return View();
        }

        public IActionResult AddAttribute(int id)
        {
            return View();
        }
    }
}
