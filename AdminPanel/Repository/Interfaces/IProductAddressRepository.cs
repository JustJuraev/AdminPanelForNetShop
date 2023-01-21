using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IProductAddressRepository
    {
        void Add(ProductAddress productAddress, List<int> list);

        void Remove(ProductAddress productAddress);

        void Update(List<ProductAddress> productAddress);

        List<ProductAddress> GetAll();

        ProductAddress GetById(int id);

    
    }
}
