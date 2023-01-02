using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
