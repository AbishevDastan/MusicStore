using Diploma.Domain.Entities;
using Diploma.DTO.Category;

namespace Diploma.BusinessLogic.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto?> GetCategory(int categoryId);

        //Admin Panel
        Task<List<CategoryDto>> GetAdminCategories();
        Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto categoryDto);
        Task<bool> DeleteCategory(int categoryId);
    }
}
