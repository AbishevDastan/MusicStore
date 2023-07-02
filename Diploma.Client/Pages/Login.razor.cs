using Diploma.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;

namespace Diploma.Client.Pages
{
    public partial class Login
    {
        private AuthenticateUserDto user = new AuthenticateUserDto();
        private string previousUrl = string.Empty;
        private string ErrorMessage = string.Empty;

        protected override void OnInitialized()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("previousUrl", out var url))
            {
                previousUrl = url;
            }
        }
        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if(result.Success)
            {
                ErrorMessage = string.Empty;
                await LocalStorageService.SetItemAsync("token", result.Data);
                await AuthStateProvider.GetAuthenticationStateAsync();
                NavigationManager.NavigateTo(previousUrl);
            }
            else
            {
                ErrorMessage = result.Message;
            }
        }
    }
}
