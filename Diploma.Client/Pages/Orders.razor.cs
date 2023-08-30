using Diploma.DTO.Order;

namespace Diploma.Client.Pages
{
    public partial class Orders
    {
        public List<OrderOverview> orders;

        protected override async Task OnInitializedAsync()
        {
            orders = await OrderService.GetOrdersForUser();
            BreadcrumbService.ClearBreadcrumbs();
            BreadcrumbService.AddBreadcrumb("Home", "/");
            BreadcrumbService.AddBreadcrumb("Orders", "/orders");
        }
    }
}
