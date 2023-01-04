using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private ApplicationContext _context;

        public ProductPropertyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProductProperty GetById(int id)
        {
            return _context.ProductProperties.FirstOrDefault(p => p.Id == id); 
        }
        public List<ProductProperty> Get(int id) 
        {
            return _context.ProductProperties.Include(x => x.Property).Where(x => x.ProductId == id).ToList();
        }

        public void Add(ProductProperty productProperty) 
        { 
           _context.ProductProperties.Add(productProperty);
            _context.SaveChanges();
        }

        public void Delete(ProductProperty productProperty) 
        { 
            _context.ProductProperties.Remove(productProperty);
            _context.SaveChanges();
        }

        public void Update(List<ProductProperty> productProperties) 
        { 
            foreach(var item in productProperties) 
            { 
                _context.ProductProperties.Update(item);
            }
            _context.SaveChanges();
        }
    }
}
