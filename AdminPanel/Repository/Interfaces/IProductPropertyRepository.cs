using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IProductPropertyRepository
    {
        ProductProperty GetById(int id);

        void Delete(ProductProperty productProperty);

        void Add(ProductProperty productProperty);

        void Update(List<ProductProperty> productProperties);

        List<ProductProperty> Get(int id);
    }
}
