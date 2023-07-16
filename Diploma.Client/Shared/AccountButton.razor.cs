using Microsoft.AspNetCore.Components.Authorization;


namespace Diploma.Client.Shared
{
    public partial class AccountButton
    {
        private async Task Logout()
        {
            await LocalStorageService.RemoveItemAsync("token");
            await CartService.GetNumberOfCartItems();
            await AuthStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");
        }
    }
}
