using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        [Parameter]
        public string? CategoryUrl { get; set; } = null;
        private bool isLoading = true;
        private string errorMessage;
        protected override async Task OnParametersSetAsync()
        {
            try
            {
                await ItemService.GetItems(CategoryUrl);
            }
            catch (Exception ex)
            {
                errorMessage = "Sorry, an error occurred while fetching products.";
            }
            isLoading = false;
        }
        protected override void OnInitialized()
        {
            ItemService.ItemsChanged += StateHasChanged;
            CategoryService.GetCategories();
        }

        public void Dispose()
        {
            ItemService.ItemsChanged -= StateHasChanged;
        }
    }
}
