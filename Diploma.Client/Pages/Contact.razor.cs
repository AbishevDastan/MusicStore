namespace Diploma.Client.Pages
{
    public partial class Contact
    {
        protected override void OnInitialized()
        {
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Contact", "/contact");
        }
    }
}
