using AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {
      
        public IActionResult Products()
        {
            return View();
        }
    }
}
