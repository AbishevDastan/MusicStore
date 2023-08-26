using Diploma.DTO.Order;

namespace Diploma.Client.Pages
{
    public partial class Orders
    {
        public List<OrderOverview> orders;

        protected override async Task OnInitializedAsync()
        {
            orders = await _orderService.GetOrdersForUser();
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Orders", "/orders");
        }
    }
}
