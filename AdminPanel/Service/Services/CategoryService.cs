using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) 
        { 
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
           return _categoryRepository.GetById(id);
        }

        public void Remove(Category category)
        {
            _categoryRepository.Remove(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
