using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
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
            return View(model);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
    }
}
