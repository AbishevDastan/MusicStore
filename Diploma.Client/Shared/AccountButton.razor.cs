namespace Diploma.Client.Shared
{
    public partial class AccountButton
    {
        private async Task Logout()
        {
            await LocalStorageService.RemoveItemAsync("cartItemsCount");
            await LocalStorageService.RemoveItemAsync("wishlistItemsCount");
            await LocalStorageService.RemoveItemAsync("token");
            await AuthStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");

            StateHasChanged();
        }
    }
}
