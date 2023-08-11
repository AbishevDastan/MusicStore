using Diploma.Client.Services.ItemService;
using Diploma.DTO.Category;
using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Shared
{
    public partial class HomeMainSection
    {
        protected override async Task OnInitializedAsync()
        {
            await _categoryService.GetCategories();
        }

        private void GoToCategories()
        {
            _navigationManager.NavigateTo("#categories");
        }
    }
}
