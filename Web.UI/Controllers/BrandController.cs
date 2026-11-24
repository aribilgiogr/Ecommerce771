using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService service;

        public BrandController(IBrandService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetBrands());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.CreateBrandAsync(model);
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
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var reply = await service.DeleteBrandAsync(id);
            if (reply.IsSuccess)
            {
                return RedirectToAction("index");
            }
            string errors = reply.Errors != null ? string.Join(", ", reply.Errors) : "";
            return Problem(errors);
        }

        public IActionResult Edit(int id)
        {
            var brand = service.GetBrand(id);
            if (brand != null)
            {
                return View(brand);
            }
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.UpdateBrandAsync(model);
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
            return View(model);
        }
    }
}
