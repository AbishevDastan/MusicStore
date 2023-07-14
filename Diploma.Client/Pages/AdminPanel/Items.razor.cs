using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class Items
    {        
        protected override async Task OnInitializedAsync()
        {
           await ItemService.GetAdminItems();
        }

        void ShowItem(int itemId)
        {
            NavigationManager.NavigateTo($"item/admin/{itemId}");
        }

        void CreateNewItem()
        {
            NavigationManager.NavigateTo("/item/admin");
        }
    }
}
