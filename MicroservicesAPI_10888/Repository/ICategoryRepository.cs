using System.Collections.Generic;
using MicroservicesAPI_10888.Models;

namespace MicroservicesAPI_10888.Repository
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetCategories();
    }
}