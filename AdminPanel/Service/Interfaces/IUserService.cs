using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();

        void DeleteUser(User user);

        User GetById(int id);
    }
}
