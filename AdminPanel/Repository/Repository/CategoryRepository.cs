using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        private string path = Directory.GetCurrentDirectory() + "\\wwwroot\\categories\\images\\";

        public CategoryRepository(ApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        private string AddPhoto(Category category)
        {
            string fileName = null;

            if (category.CoverPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "categories/images");
                string str = Path.GetExtension(category.CoverPhoto.FileName);
                fileName = Guid.NewGuid().ToString() + str;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    category.CoverPhoto.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public void Add(Category category)
        {
            category.Image = AddPhoto(category);

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Category category)
        {
            if (File.Exists($"{path}{category.Image}"))
            {
                File.Delete($"{path}{category.Image}");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {

            if (category.CoverPhoto != null)
            {
                var oldProduct = GetById(category.Id);
                if (File.Exists($"{path}{oldProduct.Image}"))
                {
                    File.Delete($"{path}{oldProduct.Image}");
                }

                category.Image = AddPhoto(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
