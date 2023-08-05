using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        [Parameter]
        public string? CategoryUrl { get; set; } = null;
        protected override async Task OnParametersSetAsync()
        {
            await _itemService.GetItems(CategoryUrl);
        }
        protected override void OnInitialized()
        {
            _itemService.ItemsChanged += StateHasChanged;
            _categoryService.GetCategories();
        }

        public void Dispose()
        {
            _itemService.ItemsChanged -= StateHasChanged;
        }
    }
}
