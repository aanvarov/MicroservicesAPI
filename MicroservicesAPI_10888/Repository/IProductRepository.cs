using System.Collections.Generic;
using MicroservicesAPI_10888.Models;

namespace MicroservicesAPI_10888.Repository
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
    }
}