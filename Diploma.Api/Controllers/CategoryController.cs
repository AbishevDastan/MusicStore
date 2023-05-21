using AutoMapper;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);

            return Ok(categoriesDTO);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<ActionResult<Item>> GetCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                return Ok(categoryDTO);
            }
        }
    }
}
