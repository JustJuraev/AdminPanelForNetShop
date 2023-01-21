using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using AdminPanel.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Controllers
{
    public class ProductAddressController : Controller
    {

        private IProductService _productService;
        private IProductAddressService _productAddressService;
        private IRegionService _regionService;

        public ProductAddressController(IProductService productService, IProductAddressService productAddressService, 
            IRegionService regionService)
        {
            _productService = productService;
            _productAddressService = productAddressService;
            _regionService = regionService;
        }

        public IActionResult Add()
        {
            ViewBag.Products = _productService.GetAll();
            ViewBag.Region = _regionService.GetAll();   
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddress productAddress, List<int> list) 
        {
            _productAddressService.Add(productAddress, list);
            return RedirectToAction("Products", "Product");
        }

        //TODO: Доделать select в update.cs
        public IActionResult Update(int id)
        {
            var list = _productAddressService.GetAll().Where(x => x.ProductId == id).ToList();
           
            ViewBag.AllReg = _regionService.GetAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult Update(List<ProductAddress> list) 
        {
            _productAddressService.Update(list);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Delete(int id)
        {
            _productAddressService.Remove(_productAddressService.GetById(id));

            return RedirectToAction("Products", "Product");
        }
    }
}
