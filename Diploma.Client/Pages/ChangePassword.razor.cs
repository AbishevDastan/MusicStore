using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class ChangePassword
    {
        ChangePasswordDto request = new ChangePasswordDto();
        bool success;

        private async Task ProvideNewPassword()
        {
            var result = await AuthService.ChangePassword(request);
            success = true;
            StateHasChanged();
        }
    }
}
