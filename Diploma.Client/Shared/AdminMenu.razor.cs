using System.Security.Claims;

namespace Diploma.Client.Shared
{
    public partial class AdminMenu
    {
        bool authorized = false;

        protected override async Task OnInitializedAsync()
        {
            string role = (await AuthenticationStateProvider.GetAuthenticationStateAsync())
            .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role.Contains("Admin"))
            {
                authorized = true;
            }
        }
    }
}
