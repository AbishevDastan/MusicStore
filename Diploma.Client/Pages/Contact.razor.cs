namespace Diploma.Client.Pages
{
    public partial class Contact
    {
        protected override async Task OnInitializedAsync()
        {
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Contact", "/contact");
        }
    }
}
