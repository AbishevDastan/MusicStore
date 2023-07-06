using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        event Action OnChange;
        List<CategoryDto> Categories { get; set; }
        List<CategoryDto> AdminCategories { get; set; }

        Task GetCategories();
        Task<CategoryDto> GetCategory(int categoryId);

        Task GetAdminCategories();
        Task AddCategory(CategoryDto categoryDTO);
        CategoryDto CreateCategory();
        //Task RemoveCategory(int categoryId);
        Task UpdateCategory(CategoryDto categoryDTO);
    }
}
