using Diploma.DTO.Order;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrders
    {
        private int orderCount;
        private List<OrderOverview> orders = new List<OrderOverview>();

        protected override async Task OnInitializedAsync()
        {
            orders = await _orderService.GetOrdersForAdmin();
            orderCount = await _orderService.GetOrdersCount();
        }

        public async Task ApproveOrder(int orderId)
        {
            await _orderService.ApproveOrder(orderId);
        }
    }
}
