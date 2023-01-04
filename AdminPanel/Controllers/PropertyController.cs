using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
