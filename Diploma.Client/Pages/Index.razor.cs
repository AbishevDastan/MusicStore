using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Index
    {
        [Parameter]
        public string? CategoryUrl { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await ItemService.GetItems(CategoryUrl);
        }
    }
}
