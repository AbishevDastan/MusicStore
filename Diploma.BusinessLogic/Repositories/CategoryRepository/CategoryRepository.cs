using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
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

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var category = await _dataContext.Categories.FindAsync(categoryId);

            return category;
        }
    }
}
