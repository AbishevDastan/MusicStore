using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.DTO.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CategoryDto?> GetCategory(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        //Admin Panel
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<List<CategoryDto>> GetAdminCategories()
        {
            return await _categoryRepository.GetAdminCategories();
        }

        [HttpPost]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<CategoryDto?> CreateCategory(CategoryDto categoryDto)
        {
            return await _categoryRepository.CreateCategory(categoryDto);
        }

        [HttpDelete]
        [Route("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> RemoveCategory(int id)
        {
            //var category = await _categoryRepository.GetCategory(categoryId);
            //if (category == null)
            //{
            //    return false;
            //}
            return await _categoryRepository.DeleteCategory(id);
        }


        [HttpPut]
        [Route("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<CategoryDto?> UpdateCategory(int id, CategoryDto categoryDto)
        {
            return await _categoryRepository.UpdateCategory(id, categoryDto);
        }
    }
}
