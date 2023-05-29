using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class UserProfile
    {
        ChangePasswordDTO request = new ChangePasswordDTO();
        string message = string.Empty;

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
        }
    }
}
