using AdminPanel.Models;
using AdminPanel.Models.Helpers;
using AdminPanel.Models.ViewModel;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AdminPanel.Service.Services
{
    public class AccountService : IAccountService
    {
        private IUserService _userRepository;
        public AccountService(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsIdentity Login(LoginViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);

            if (user != null && user.Password == HashPasswordHelper.HashPassword(model.Password))
            {
                var result = Authenticate(user);
                return result;
            }

            return new ClaimsIdentity();
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
