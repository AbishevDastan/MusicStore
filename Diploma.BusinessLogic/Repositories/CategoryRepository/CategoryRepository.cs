using AutoMapper;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO.Category;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;
        }

        public async Task<CategoryDto?> GetCategory(int categoryId)
        {
            var category = await _dataContext.Categories.FindAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<List<CategoryDto>> GetAdminCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Url = categoryDto.Url,
                ImageUrl = categoryDto.ImageUrl
            };

            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();

            categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _dataContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return false;
            }
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto categoryDto)
        {
            var category = await _dataContext.Categories.FindAsync(categoryId);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                category.Url = categoryDto.Url;
                category.ImageUrl = categoryDto.ImageUrl;

                await _dataContext.SaveChangesAsync();
            }
            categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
    }
}
