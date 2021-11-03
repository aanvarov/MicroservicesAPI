using MicroservicesAPI_10888.Models;
using Microsoft.EntityFrameworkCore;
namespace MicroservicesAPI_10888.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}