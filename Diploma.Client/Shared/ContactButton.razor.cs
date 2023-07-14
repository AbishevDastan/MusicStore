using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Shared
{
    public partial class ContactButton
    {
        private void NavigateToContactPage()
        {
            NavigationManager.NavigateTo("contact");
        }
    }
}
