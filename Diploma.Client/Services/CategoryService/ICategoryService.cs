using Diploma.DTO.Category;

namespace Diploma.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryDto> Categories { get; set; }
        List<CategoryDto> AdminCategories { get; set; }
        event Action CategoriesChanged;

        string Message { get; set; }

        Task GetCategories();
        Task<CategoryDto?> GetCategory(int id);

        Task GetAdminCategories();
        Task CreateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(int id, CategoryDto categoryDto);
    }
}

