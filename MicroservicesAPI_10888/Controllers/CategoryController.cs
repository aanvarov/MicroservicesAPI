using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MicroservicesAPI_10888.Models;
using MicroservicesAPI_10888.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesAPI_10888.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryRepository.GetCategories();
            return new OkObjectResult(categories);
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return new OkObjectResult(category);
            // return "value";
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.InsertCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new {id = category.Id}, category);
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.UpdateCategory(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return new OkResult();

        }
    }
}
