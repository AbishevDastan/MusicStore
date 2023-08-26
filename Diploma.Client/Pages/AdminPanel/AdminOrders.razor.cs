using Diploma.DTO.Order;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrders
    {
        private int orderCount;
        private List<OrderOverview> orders = new List<OrderOverview>();

        protected override async Task OnInitializedAsync()
        {
            orders = await OrderService.GetOrdersForAdmin();
            orderCount = await OrderService.GetOrdersCount();
        }

        public async Task ApproveOrder(int orderId)
        {
            await OrderService.ApproveOrder(orderId);
            StateHasChanged();
            orders = await OrderService.GetOrdersForAdmin();
        }
    }
}
