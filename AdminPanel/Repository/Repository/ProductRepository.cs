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
            return _context.Products.OrderBy(x => x.Id).AsNoTracking().ToList();
        }

        public void Add(Product product) 
        { 
            product.Image = AddPhoto(product);

            product.StockId = 1;

            var log = new Log
            { 
                BarCode = product.BarCode,
                Count = product.Count,
                Type = "income",
                TotalPrice = product.Count * product.PriceIncome,
                Time = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            if (File.Exists($"{path}{product.Image}"))
            {
                File.Delete($"{path}{product.Image}");
            }

            var log = new Log
            {
                BarCode = product.BarCode,
                Count = product.Count,
                Type = "delete",
                TotalPrice = product.Count * product.PriceOutCome,
                Time = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            product.StockId = 1;
            if(product.CoverPhoto != null) 
            {
                var oldProduct = GetById(product.Id);
                if (File.Exists($"{path}{oldProduct.Image}"))
                {
                    File.Delete($"{path}{oldProduct.Image}");
                }

                product.Image = AddPhoto(product);
            }
            else
            {
                var oldProduct = GetById(product.Id);
                product.Image = oldProduct.Image;
            }

            var log = new Log
            {
                BarCode = product.BarCode,
                Count = product.Count,
                Type = "change",
                TotalPrice = product.Count * product.PriceIncome,
                Time = DateTime.Now
            };

            _context.Products.Update(product);
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}

