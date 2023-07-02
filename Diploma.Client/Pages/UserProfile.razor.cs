using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class UserProfile
    {
        ChangePasswordDto request = new ChangePasswordDto();
        string message = string.Empty;

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
        }
    }
}
