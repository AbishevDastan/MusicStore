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
        public async Task<ActionResult<List<CategoryDto>>> AddCategory(CreateCategoryDto dto)
        {
            var returnedCategory = await _categoryRepository.AddCategory(dto);

            return returnedCategory;
        }

        //[HttpDelete]
        //[Route("admin/{id}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult> RemoveCategory(int categoryId)
        //{
        //    var category = await _categoryRepository.GetCategory(categoryId);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    await _categoryRepository.RemoveCategory(categoryId);

        //}

        [HttpPut]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<CategoryDto>>> UpdateCategory(Category category)
        {
            var returnedCategory = await _categoryRepository.UpdateCategory(category);
            if (category == null)
            {
                return NotFound();
            }

            return returnedCategory;
        }
    }
}
