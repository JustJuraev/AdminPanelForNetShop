using AdminPanel.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View(_userRepository.GetAll());
        }
    }
}
