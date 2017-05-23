using Microsoft.AspNetCore.Mvc;
using DubrovkaSupplyLazurin.ViewModels;
using DubrovkaSupplyLazurin.Models;
using Microsoft.AspNetCore.Authorization;

namespace DubrovkaSupplyLazurin.Controllers
{
    [Authorize]
    public class CategorySkuController : Controller
    {
        private readonly ICategorySkuRepository _categorySkuRepository;

        public CategorySkuController(ICategorySkuRepository categprySkuRepository)
        {
            _categorySkuRepository = categprySkuRepository;
        }

        public IActionResult Index()
        {
            var model = new CategorySkuListViewModel
            {
                CaterorySkus = _categorySkuRepository.CategorySkus
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategorySkuViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categorySkuRepository.Create(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _categorySkuRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategorySkuViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categorySkuRepository.Edit(id, model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
