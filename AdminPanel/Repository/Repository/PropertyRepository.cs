using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private ApplicationContext _context;

        public PropertyRepository(ApplicationContext context) 
        { 
           _context = context;
        }

        public void Add(Property item)
        {
            _context.Properties.Add(item);
            _context.SaveChanges();
        }

        public List<Property> GetAll()
        {
           return  _context.Properties.AsNoTracking().ToList();
        }

        public Property GetById(int id)
        {
            return _context.Properties.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Property item)
        {
             _context.Properties.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Property item)
        {
            _context.Properties.Update(item);
            _context.SaveChanges();
        }
    }
}
