using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class Registration
    {
        CreateUserDto user = new CreateUserDto();

        bool success;

        async Task HandleRegistration()
        {
            var result = await UserService.Register(user);
            success = true;
            StateHasChanged();
        }

        void GoToLogin()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}
