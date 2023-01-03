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
    public class ProductRepository : IProductRepository
    {
        private ApplicationContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        private string path = Directory.GetCurrentDirectory() + "\\wwwroot\\products\\images\\";

        public ProductRepository(ApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        private string AddPhoto(Product product)
        {
            string fileName = null;

            if(product.CoverPhoto != null) 
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "products/images");
                string str = Path.GetExtension(product.CoverPhoto.FileName);
                fileName = Guid.NewGuid().ToString() + str;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create)) 
                { 
                    product.CoverPhoto.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public List<Product> GetAll()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public void Add(Product product) 
        { 
            product.Image = AddPhoto(product);

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            if (File.Exists($"{path}{product.Image}"))
            {
                File.Delete($"{path}{product.Image}");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
          
            if(product.CoverPhoto != null) 
            {
                var oldProduct = GetById(product.Id);
                if (File.Exists($"{path}{oldProduct.Image}"))
                {
                    File.Delete($"{path}{oldProduct.Image}");
                }

                product.Image = AddPhoto(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
//TODO: Сделать сервис для продуктов
//TODO: Заменить в контролере ссылки на сервис
//TODO: Добавить удаление и обновление продуктов
//TODO: Добавить категории