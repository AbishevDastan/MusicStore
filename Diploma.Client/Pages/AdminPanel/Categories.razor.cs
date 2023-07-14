using Diploma.DTO;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class Categories
    {
        public int? Id { get; set; }

        CategoryDto categoryDto = new CategoryDto { Name = "New Product" };

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetAdminCategories();
        }

        void ShowCategory(int categoryId)
        {
            NavigationManager.NavigateTo($"category/admin/{categoryId}");
        }

        void CreateNewCategory()
        {
            NavigationManager.NavigateTo("/category/admin");
        }

        async Task DeleteCategory()
        {
            await CategoryService.DeleteCategory(categoryDto.Id);
        }
    }
}
