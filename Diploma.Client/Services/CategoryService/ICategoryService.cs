using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryDto> Categories { get; set; }
        List<CategoryDto> AdminCategories { get; set; }
        string Message { get; set; }

        Task GetCategories();
        Task<CategoryDto?> GetCategory(int id);

        Task GetAdminCategories();
        Task CreateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(int id, CategoryDto categoryDto);
    }
}

