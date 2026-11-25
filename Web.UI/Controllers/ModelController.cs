using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService service;

        public ModelController(IModelService service)
        {
            this.service = service;
        }

        // GET: ModelController
        public ActionResult Index()
        {
            return View(service.GetModels());
        }

        // GET: ModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModelDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await  service.CreateModelAsync(model);
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

        // GET: ModelController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetModel(id);
            if (model != null)
            {
                return View(model);
            }
            return NotFound();
        }

        // POST: ModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ModelDto model)
        {
            if (ModelState.IsValid)
            {
                var reply = await service.UpdateModelAsync(model);
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

        // POST: ModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var reply = await service.DeleteModelAsync(id);
            if (reply.IsSuccess)
            {
                return RedirectToAction("index");
            }
            string errors = reply.Errors != null ? string.Join(", ", reply.Errors) : "";
            return Problem(errors);
        }
    }
}
