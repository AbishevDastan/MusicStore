using Diploma.Client.Services.WishlistService;
using Diploma.DTO.User;

namespace Diploma.Client.Pages
{
    public partial class Login
    {
        private AuthenticateUserDto user = new AuthenticateUserDto();
        private string ErrorMessage = string.Empty;
        bool success;

        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if (result.Success)
            {
                ErrorMessage = string.Empty;
                await LocalStorageService.SetItemAsync("token", result.Data);
                await AuthStateProvider.GetAuthenticationStateAsync();
                await CartService.PostCartItemsToDatabase(true);
                await WishlistService.PostWishlistItemsToDatabase(true);
                await CartService.GetNumberOfCartItems();
                await WishlistService.GetNumberOfWishlistItems();
                success = true;
                NavigationManager.NavigateTo("");
                StateHasChanged();
            }
            else
            {
                ErrorMessage = result.Message;
            }
        }

        void GoToRegistration()
        {
            NavigationManager.NavigateTo("register");
        }
    }
}
