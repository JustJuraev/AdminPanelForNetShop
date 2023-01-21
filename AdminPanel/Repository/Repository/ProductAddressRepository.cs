using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class ProductAddressRepository : IProductAddressRepository
    {
        private ApplicationContext _context;

        public ProductAddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(ProductAddress productAddress, List<int> list)
        {
            foreach(var item in list)
            {
                var newproductAddress = new ProductAddress
                { 
                   ProductId = productAddress.ProductId,
                   RegionId = item
                };
                _context.ProductAddresses.Add(newproductAddress);
            }
            _context.SaveChanges();
        }

        public void Remove(ProductAddress productAddress) 
        { 
            _context.ProductAddresses.Remove(productAddress);
            _context.SaveChanges();
        }

        public void Update(List<ProductAddress> productAddress) 
        { 
            foreach(var item in productAddress) 
            { 
                _context.ProductAddresses.Update(item);
            }
            _context.SaveChanges();
        }

        public List<ProductAddress> GetAll()
        {
            return _context.ProductAddresses.AsNoTracking().ToList();
        }

        public ProductAddress GetById(int id)
        {
            return _context.ProductAddresses.FirstOrDefault(x => x.Id == id);
        }

       
    }
}
