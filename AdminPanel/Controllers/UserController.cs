using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userRepository;

        public UserController(IUserService userRepository) 
        { 
            _userRepository = userRepository;
        }

        public IActionResult Users()
        {
            return View(_userRepository.GetAll());
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(_userRepository.GetById(id));

            return RedirectToAction("Index");
        } 
    }
}
