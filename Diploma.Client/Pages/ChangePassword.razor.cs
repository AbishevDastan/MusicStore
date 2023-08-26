using Diploma.DTO.User;
using MudBlazor;

namespace Diploma.Client.Pages
{
    public partial class ChangePassword
    {
        ChangePasswordDto request = new ChangePasswordDto();
        bool success;

        private async Task ProvideNewPassword()
        {
            var result = await UserService.ChangePassword(request);
            success = true;
            StateHasChanged();
        }
    }
}
