using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class Login
    {
        private AuthenticateUserDTO user = new AuthenticateUserDTO();

        private async Task HandleLogin()
        {
            Console.WriteLine("Log me in");
        }
    }
}
