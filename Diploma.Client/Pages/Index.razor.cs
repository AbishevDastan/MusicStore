using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Index
    {
        [Parameter]
        public string? CategoryUrl { get; set; } = null;
        [Parameter]
        public string? SearchText { get; set; } = null;

        protected override async Task OnParametersSetAsync()
        {
            if(SearchText != null) 
            {
                await ItemService.SearchItem(SearchText);
            }
            else
            await ItemService.GetItems(CategoryUrl);
        }
    }
}
