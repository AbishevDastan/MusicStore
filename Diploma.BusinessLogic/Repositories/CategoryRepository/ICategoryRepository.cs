using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategories();
        Task<List<CategoryDto>> GetAdminCategories();
        Task<List<CategoryDto>> AddCategory(CategoryDto category);
        Task<List<CategoryDto>> UpdateCategory(CategoryDto category);
        Task<List<CategoryDto>> RemoveCategory(int categoryId);
        Task<CategoryDto> GetCategory(int categoryId);
    }
}
