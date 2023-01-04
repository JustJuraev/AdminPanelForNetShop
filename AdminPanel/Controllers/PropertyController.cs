using AdminPanel.Models;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class PropertyController : Controller
    {
        private IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            return View(_propertyService.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Property property) 
        { 
            _propertyService.Add(property);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        { 
            _propertyService.Remove(_propertyService.GetById(id));

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(_propertyService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Property property) 
        { 
            _propertyService.Update(property);

            return RedirectToAction("Index");
        }
    }
}
