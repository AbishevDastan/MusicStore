using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Diploma.Client.Shared
{
    public partial class Search
    {
        //public async void SearchItems(ChangeEventArgs args)
        //{
        //    var searchItem = (string)args.Value;

        //}
        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();
        protected ElementReference searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
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
