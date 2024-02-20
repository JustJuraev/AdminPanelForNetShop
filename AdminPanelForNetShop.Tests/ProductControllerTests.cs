using AdminPanel.Controllers;
using AdminPanel.Models;
using AdminPanel.Repository.Repository;
using AdminPanel.Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdminPanelForNetShop.Tests
{
    public class ProductControllerTests
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment webHostEnvironment;

        public ProductControllerTests()
        {

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _configuration = configurationBuilder;
        }

        [Fact]
        public void CheckIfGetAllNotNull()
        {
            var connectionString = "server=localhost;port=5432;Database=newshop;UserId=postgres;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);
            using(var context = new ApplicationContext(optionsBuilder.Options)) 
            { 
                //Assert

                //Подключаем репозитори
                var productRepository = new ProductRepository(context, webHostEnvironment);
                var categoryRepository = new CategoryRepository(context, webHostEnvironment);
                //Подключаем Service
                var productService = new ProductService(productRepository);
                var categoryService = new CategoryService(categoryRepository);

                var controller = new ProductController(productService, categoryService);

                //Act
                var result = controller.Products();

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
                Assert.True(model.Count > 0);

            }
        }

        //[Fact]
        //public void CheckIfAddAreAdding()
        //{
        //    var connectionString = "server=localhost;port=5432;Database=newshop2;UserId=postgres;Password=123456;";
        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        //    optionsBuilder.UseNpgsql(connectionString);
        //    using(var context = new ApplicationContext(optionsBuilder.Options))
        //    {
        //        //Assert

        //        //Подключаем репозитори
        //        var productRepository = new ProductRepository(context, webHostEnvironment);
        //        var categoryRepository = new CategoryRepository(context, webHostEnvironment);
        //        //Подключаем Service
        //        var productService = new ProductService(productRepository);
        //        var categoryService = new CategoryService(categoryRepository);

        //        var controller = new ProductController(productService, categoryService);

        //        //Act
        //        Product product = new Product { Id = 1 };
        //        var result = controller.Add(product);

        //        //Assert
        //        var addedProduct = context.Products.Find(product.Id);
        //        Assert.NotNull(addedProduct);
        //    }
        //}

        [Fact]
        public void CheckIfRemoveAreRemoved()
        {
            var connectionString = "server=localhost;port=5432;Database=newshop2;UserId=postgres;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);
            using(var context = new ApplicationContext(optionsBuilder.Options))
            {
                //Assert

                //Подключаем репозитори
                var productRepository = new ProductRepository(context, webHostEnvironment);
                var categoryRepository = new CategoryRepository(context, webHostEnvironment);
                //Подключаем Service
                var productService = new ProductService(productRepository);
                var categoryService = new CategoryService(categoryRepository);

                var controller = new ProductController(productService, categoryService);

                //Act
                Product product = new Product { Id = 1 };
                var result = controller.Remove(product.Id);

                //Assert
                var addedProduct = context.Products.Find(product.Id);
                Assert.Null(addedProduct?.Id);
                Assert.Null(addedProduct?.Name);


            }
        }
    }
}
