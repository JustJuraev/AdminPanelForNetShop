using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Categories()
        {
            return View(_categoryService.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        { 
            _categoryService.Remove(_categoryService.GetById(id));

            return RedirectToAction("Categories");
        }

        public IActionResult Update(int id)
        {
            return View(_categoryService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {

            _categoryService.Update(category);

            return RedirectToAction("Categories");
        }

    }
}
