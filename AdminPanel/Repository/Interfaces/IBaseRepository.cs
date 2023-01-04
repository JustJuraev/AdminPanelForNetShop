using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();

        void Add(T item);

        void Remove(T item);

        void Update(T item);

        T GetById(int id);
    }
}
