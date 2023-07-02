using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategories();
        //Task<List<CategoryDTO>> GetAdminCategories();
        //Task<List<CategoryDTO>> AddCategory(CategoryDTO category);
        //Task<List<CategoryDTO>> UpdateCategory(CategoryDTO category);
        //Task<List<CategoryDTO>> RemoveCategory(int categoryId);
        Task<CategoryDto> GetCategory(int categoryId);
    }
}
