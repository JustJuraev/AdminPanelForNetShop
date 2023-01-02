using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        void DeleteUser(User user);

        User GetById(int id);
    }
}
