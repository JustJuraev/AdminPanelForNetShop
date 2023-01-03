using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        void Add(Product product);

        void Remove(Product product);

        void Update(Product product);

        Product GetById(int id);
    }
}
