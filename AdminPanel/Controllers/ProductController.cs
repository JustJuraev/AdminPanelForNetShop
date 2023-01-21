using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Repository.Repository;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {
      
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Products()
        {
            return View(_productService.GetAll());
        }

        public IActionResult Add() 
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product) 
        { 
            _productService.Add(product);
           
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _productService.Remove(_productService.GetById(id));

            return RedirectToAction("Products");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View(_productService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            
            _productService.Update(product);

            return RedirectToAction("Products");
        }
    }
}
