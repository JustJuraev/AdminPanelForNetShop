using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdminPanel.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<ProductProperty> ProductProperties { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductAddress> ProductAddresses { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<OrderBasket> OrderItems { get; set; }
    }
}
