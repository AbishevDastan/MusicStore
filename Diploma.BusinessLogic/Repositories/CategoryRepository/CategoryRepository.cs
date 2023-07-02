using AutoMapper;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;
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

        //public async Task<List<CategoryDTO>> AddCategory(CategoryDTO categoryDto)//Needs to be done!!!
        //{
        //    categoryDto.IsBeingEdited = false;
        //    categoryDto.IsNew = false;

        //    var category = _mapper.Map<Category>(categoryDto);

        //    await _dataContext.Categories.AddAsync(category);
        //    await _dataContext.SaveChangesAsync();

        //    return await GetAdminCategories();
        //}

        //public async Task<List<CategoryDTO>> GetAdminCategories()
        //{
        //    var categories = await _dataContext.Categories
        //        .Where(c => !c.IsRemoved)
        //        .ToListAsync();

        //    var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);

        //    return categoriesDTO;
        //}

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

        //public async Task<List<CategoryDTO>> RemoveCategory(int categoryId)
        //{
        //    CategoryDTO categoryDto = await GetCategory(categoryId);
        //    categoryDto.IsRemoved = true;

        //    await _dataContext.SaveChangesAsync();

        //    return await GetAdminCategories();
        //}

        //public async Task<List<CategoryDTO>> UpdateCategory(CategoryDTO categoryDto)
        //{
        //    var dbCategory = await GetCategory(categoryDto.Id);
        //    dbCategory.Name = categoryDto.Name;
        //    dbCategory.Url = categoryDto.Url;
        //    dbCategory.IsVisible = categoryDto.IsVisible;

        //    var category = _mapper.Map<List<Category>>(dbCategory);

        //    await _dataContext.SaveChangesAsync();

        //    return await GetAdminCategories();
        //}
    }
}
