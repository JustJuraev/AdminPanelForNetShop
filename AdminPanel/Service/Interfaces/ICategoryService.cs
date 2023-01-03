using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        void Add(Category category);

        void Remove(Category category);

        void Update(Category category);

        Category GetById(int id);
    }
}
