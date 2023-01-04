using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IProductPropertyService
    {
        ProductProperty GetById(int id);

        void Delete(ProductProperty productProperty);

        void Add(ProductProperty productProperty);

        void Update(List<ProductProperty> productProperties);

        List<ProductProperty> Get(int id);
    }
}
