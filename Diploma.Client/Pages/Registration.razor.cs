using Diploma.DTO;
using System.Net;

namespace Diploma.Client.Pages
{
    public partial class Registration
    {
        CreateUserDTO user = new CreateUserDTO();

        string message = string.Empty;
        string messageCssClass = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            message = result.Message;
            if (result.Success)
                messageCssClass = "text-success";
            else
                messageCssClass = "text-danger";
        }
    }
}
