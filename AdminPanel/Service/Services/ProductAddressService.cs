using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class ProductAddressService : IProductAddressService
    {

        private IProductAddressRepository _productAddressRepository;

        public ProductAddressService(IProductAddressRepository productAddressRepository)
        {
            _productAddressRepository = productAddressRepository;
        }

        public void Add(ProductAddress productAddress, List<int> list)
        {
           _productAddressRepository.Add(productAddress, list);
        }

        public List<ProductAddress> GetAll()
        {
            return _productAddressRepository.GetAll();
        }

        public ProductAddress GetById(int id)
        {
            return _productAddressRepository.GetById(id);
        }

        public void Remove(ProductAddress productAddress)
        {
            _productAddressRepository.Remove(productAddress);
        }

        public void Update(List<ProductAddress> productAddress)
        {
            _productAddressRepository.Update(productAddress);
        }
    }
}
