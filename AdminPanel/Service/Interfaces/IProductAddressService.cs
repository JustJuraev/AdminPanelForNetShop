using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IProductAddressService
    {
       
        void Remove(ProductAddress productAddress);

        void Update(List<ProductAddress> productAddress);

        List<ProductAddress> GetAll();

        ProductAddress GetById(int id);

        void Add(ProductAddress productAddress, List<int> list);

        
    }
}
