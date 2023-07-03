using AutoMapper;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categoriesDTO = await _categoryRepository.GetCategories();

            return Ok(categoriesDTO);
        }

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> GetAdminCategories()
        {
            var categoriesDTO = await _categoryRepository.GetAdminCategories();

            return Ok(categoriesDTO);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int categoryId)
        {
            var categoryDTO = await _categoryRepository.GetCategory(categoryId);
            if (categoryDTO == null)
            {
                return NotFound();
            }
            
            return Ok(categoryDTO);
        }

        [HttpPost]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> AddCategory(CategoryDto categoryDto)
        {
            var returnedCategory = await _categoryRepository.AddCategory(categoryDto);

            return Ok(returnedCategory);
        }

        [HttpDelete]
        [Route("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> RemoveCategory(int categoryId)
        {
            var categoryDto = await _categoryRepository.GetCategory(categoryId);
            if (categoryDto == null)
            {
                return NotFound();
            }

            var result = await _categoryRepository.RemoveCategory(categoryId);

            return Ok(result);
        }

        [HttpPut]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> UpdateCategory(CategoryDto categoryDto)
        {
            var returnedCategoryDto = await _categoryRepository.UpdateCategory(categoryDto);
            if (categoryDto == null)
            {
                return NotFound("There is no such category.");
            }

            return Ok(returnedCategoryDto);
        }
    }
}
