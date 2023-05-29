using Diploma.DTO;
using Microsoft.Data.SqlClient;

namespace Diploma.Client.Pages
{
    public partial class Login
    {
        private AuthenticateUserDTO user = new AuthenticateUserDTO();
        private string ErrorMessage = string.Empty;

        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if(result.Success)
            {
                ErrorMessage = string.Empty;
                await LocalStorageService.SetItemAsync("authenticationToken", result.Data);
                NavigationManager.NavigateTo("");
            }
            else
            {
                ErrorMessage = result.Message;
            }
        }
    }
}
