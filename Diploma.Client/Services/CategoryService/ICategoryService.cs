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
        //event Action OnChange;
        List<CategoryDto> Categories { get; set; }
        //List<CategoryDTO> AdminCategories { get; set; }
        Task GetCategories();
        //Task GetAdminCategories();
        Task<CategoryDto> GetCategory(int categoryId);
        //Task AddCategory(CategoryDTO categoryDTO);
        //Task RemoveCategory(int categoryId);
        //Task UpdateCategory(CategoryDTO categoryDTO);
        //CategoryDTO CreateCategory();
    }
}
