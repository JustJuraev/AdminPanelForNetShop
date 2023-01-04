using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class ProductPropertyService : IProductPropertyService
    {
        private IProductPropertyRepository _productPropertyRepository;

        public ProductPropertyService(IProductPropertyRepository productPropertyRepository)
        {
            _productPropertyRepository = productPropertyRepository;
        }

        public void Add(ProductProperty productProperty)
        {
            _productPropertyRepository.Add(productProperty);
        }

        public void Delete(ProductProperty productProperty)
        {
            _productPropertyRepository.Delete(productProperty);
        }

        public List<ProductProperty> Get(int id)
        {
            return _productPropertyRepository.Get(id);
        }

        public ProductProperty GetById(int id)
        {
            return _productPropertyRepository.GetById(id);
        }

        public void Update(List<ProductProperty> productProperties)
        {
            _productPropertyRepository.Update(productProperties);
        }
    }
}
