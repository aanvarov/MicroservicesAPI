using System.Collections.Generic;
using System.Linq;
using MicroservicesAPI_10888.DBContexts;
using MicroservicesAPI_10888.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesAPI_10888.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int id)
        {
            var prod = _dbContext.Products.Find(id);
            _dbContext.Entry(prod).Reference(s => s.ProductCategory).Load();
            return prod;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.Include(s => s.ProductCategory).ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}