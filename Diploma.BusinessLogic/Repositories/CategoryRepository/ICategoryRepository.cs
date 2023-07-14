using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        //Task<List<CategoryDto>> GetCategories();
        //Task<CategoryDto> GetCategory(int categoryId);
        //Task<List<CategoryDto>> AddCategory(CreateCategoryDto category);
        //Task<List<CategoryDto>> UpdateCategory(int categoryId, CategoryDto category);
        //Task<List<CategoryDto>> RemoveCategory(int categoryId);

        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto?> GetCategory(int categoryId);

        Task<List<CategoryDto>> GetAdminCategories();
        Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto categoryDto);
        Task<bool> DeleteCategory(int categoryId);
    }
}
