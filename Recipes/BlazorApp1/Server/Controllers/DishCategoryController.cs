using Microsoft.AspNetCore.Mvc;
using Recipes.Core;
using Recipes.Repos;
using Recipes.Repos.Dto;

namespace BlazorApp1.Server.Controllers
{
    public class DishCategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        public DishCategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task Create(Category category)
        {
            
          
            var createdCategories = await _categoryRepository.AddCategoryAsync(new Category()
            {
                NameCategory = category.NameCategory,
            });
        }
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task Edit(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task Delete(Category category)
        {
            await _categoryRepository.DeleteCategoryAsync(category.Id);
            
        }
        
    }
}
