using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdminPanel.Controllers
{
    public class ProductPropertyController : Controller
    {
        private IProductPropertyService _productPropertyService;
        private IPropertyRepository _propertyRepository;
        public ProductPropertyController(IProductPropertyService productPropertyService, IPropertyRepository propertyRepository)
        {
            _productPropertyService = productPropertyService;
            _propertyRepository = propertyRepository;
        }

        public IActionResult Add(int productId)
        {
            ViewBag.ProductId = productId;
            ViewBag.Property = _propertyRepository.GetAll();
            return View();
        }

        public IActionResult Delete(int id)
        {
            _productPropertyService.Delete(_productPropertyService.GetById(id));

            return RedirectToAction("Products", "Product");
        }

        [HttpPost]
        public IActionResult Add(ProductProperty productProperty)
        {
           
            _productPropertyService.Add(productProperty);

            return RedirectToAction("Products", "Product");
        }

        public IActionResult Update(int id)
        {
            return View(_productPropertyService.Get(id));
        }

        [HttpPost]
        public IActionResult Update(List<ProductProperty> list)
        {
            _productPropertyService.Update(list);

            return RedirectToAction("Products", "Product");
        }
    }
}
