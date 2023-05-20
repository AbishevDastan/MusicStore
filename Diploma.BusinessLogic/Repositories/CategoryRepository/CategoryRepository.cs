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

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var response = new ServiceResponse<List<Category>>
            {
                Data = await _dataContext.Categories.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Category>> GetCategory(int categoryId)
        {
            var response = new ServiceResponse<Category>();
            var category = await _dataContext.Categories.FindAsync(categoryId);

            if (category == null)
            {
                response.Success = false;
                response.Message = "Can not find this category.";
            }
            else
            {
                response.Data = category;
            }

            return response;
        }
    }
}
