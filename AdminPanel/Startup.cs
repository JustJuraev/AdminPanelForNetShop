using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Repository.Repository;
using AdminPanel.Service.Interfaces;
using AdminPanel.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connection = Configuration["ConnectionStrings:ConnectionString"];
            var password = Configuration["ConnectionStrings:DbPassword"];

            var builder = new NpgsqlConnectionStringBuilder(connection)
            {
                Password = password
            };
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .   AddCookie(options =>
            {
               options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
           });
          
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductAddressRepository, ProductAddressRepository>();
            services.AddScoped<IRegionRepostiory, RegionRepostiory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IProductPropertyService, ProductPropertyService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductAddressService, ProductAddressService>();
            services.AddScoped<IRegionService, RegionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
