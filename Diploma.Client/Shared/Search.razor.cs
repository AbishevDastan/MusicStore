using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace Diploma.Client.Shared
{
    public partial class Search
    {
        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();
        protected ElementReference _searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && _searchInput.Id != null)
            {
                await _searchInput.FocusAsync();
            }
        }

        public void SearchItems()
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if (args.Key == null || args.Key.Equals("Enter"))
            {
                SearchItems();
            }
            else if (searchText.Length > 1)
            {
                suggestions = await ItemService.GetItemSearchSuggestions(searchText);
            }
        }
    }
}
