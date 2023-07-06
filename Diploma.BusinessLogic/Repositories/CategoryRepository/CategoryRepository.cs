using AutoMapper;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<CategoryDto>> AddCategory(CreateCategoryDto dto)
        {
            dto.IsBeingEdited = false;
            dto.IsNew = false;

            var category = new Category
            {
                Name = dto.Name,
                Url = dto.Url
            };

            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();

            var categoryDto = await GetAdminCategories();
            return categoryDto;
        }

        public async Task<List<CategoryDto>> GetAdminCategories()
        {
            var categories = await _dataContext.Categories
                .Where(c => !c.IsRemoved)
                .ToListAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDTO;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await _dataContext.Categories
                .Where(c => !c.IsRemoved && c.IsVisible)
                .ToListAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDTO;
        }

        public async Task<CategoryDto> GetCategory(int categoryId)
        {
            var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            var categoryDTO = _mapper.Map<CategoryDto>(category);

            return categoryDTO;
        }

        //public async Task RemoveCategory(int categoryId)
        //{
        //    var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        //    category.IsRemoved = true;

        //    _dataContext.Categories.Remove(category);
        //    await _dataContext.SaveChangesAsync();
        //}

        public async Task<List<CategoryDto>> UpdateCategory(Category category)
        {
            var dbCategory = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            
            dbCategory.Name = category.Name;
            dbCategory.Url = category.Url;
            dbCategory.IsVisible = category.IsVisible;

            await _dataContext.SaveChangesAsync();

            return await GetAdminCategories();
        }
    }
}
