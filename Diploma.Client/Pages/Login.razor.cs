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
                await CartService.GetNumberOfCartItems();
                success = true;
                NavigationManager.NavigateTo("");
            }
            else
            {
                ErrorMessage = "Error occured. Please, try again.";
            }
        }

        void GoToRegistration()
        {
            NavigationManager.NavigateTo("register");
        }
    }
}
