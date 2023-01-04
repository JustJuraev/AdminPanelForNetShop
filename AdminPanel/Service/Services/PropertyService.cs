using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class PropertyService : IPropertyService
    {
        private IPropertyRepository _propertyService;

        public PropertyService(IPropertyRepository propertyService)
        {
            _propertyService = propertyService;
        }

        public void Add(Property item)
        {
           _propertyService.Add(item);
        }

        public List<Property> GetAll()
        {
           return _propertyService.GetAll();
        }

        public Property GetById(int id)
        {
            return _propertyService.GetById(id);
        }

        public void Remove(Property item)
        {
            _propertyService.Remove(item);
        }

        public void Update(Property item)
        {
            _propertyService.Update(item);
        }
    }
}
