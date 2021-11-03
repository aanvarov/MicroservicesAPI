using System.Collections.Generic;
using System.Linq;
using MicroservicesAPI_10888.DBContexts;
using MicroservicesAPI_10888.Models;

namespace MicroservicesAPI_10888.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;
        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InsertCategory(Category category)
        {
            _dbContext.Add(category);
            Save();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(category);
            Save();
        }

        public Category GetCategoryById(int id)
        {
            var category = _dbContext.Categories.Find(id);
            // _dbContext.Entry(category).Reference(s => s.ProductCategory).Load();
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            // return _dbContext.Products.Include(s => s.ProductCategory).ToList();
            return _dbContext.Categories.ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}