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
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            if(categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto?>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //Admin Panel
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> GetAdminCategories()
        {
            var adminCategory = await _categoryRepository.GetAdminCategories();
            if(adminCategory == null)
            {
                return NotFound();
            }
            return Ok(adminCategory);
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
