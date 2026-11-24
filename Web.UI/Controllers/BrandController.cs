using CORE.Abstracts.IServices;
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
    }
}
