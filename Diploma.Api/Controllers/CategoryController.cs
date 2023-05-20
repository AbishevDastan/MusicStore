using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var result = await _categoryRepository.GetCategories();
            return Ok(result);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetCategory(int categoryId)
        {
            var result = await _categoryRepository.GetCategory(categoryId);
            return Ok(result);
        }
    }
}
