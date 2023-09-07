using Diploma.DTO.Order;
using Diploma.DTO.Orders;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrders
    {
        private int orderCount;
        private List<OrderOverview> orderOverviews = new List<OrderOverview>();
        private OrderOverview orderOverview = new OrderOverview();
        private OrderStatus selectedOrderStatus;
        List<OrderStatus> orderStatusOptions = Enum.GetValues(typeof(OrderStatus))
                                                           .Cast<OrderStatus>()
                                                           .ToList();
        protected override async Task OnInitializedAsync()
        {
            orderOverviews = await OrderService.GetOrdersForAdmin();
            foreach (var order in orderOverviews)
            {
                orderOverview = order;
            }
            orderCount = await OrderService.GetOrdersCount();
        }

        public async Task ApproveOrder(int orderId)
        {
            await OrderService.ApproveOrder(orderId);
            StateHasChanged();
            orderOverviews = await OrderService.GetOrdersForAdmin();
        }

        public async Task SetStatusToShipped(int orderId)
        {
            await OrderService.SetStatusToShipped(orderId);
            StateHasChanged();
            orderOverviews = await OrderService.GetOrdersForAdmin();
        }
        public async Task SetStatusToDelivered(int orderId)
        {
            await OrderService.SetStatusToDelivered(orderId);
            StateHasChanged();
            orderOverviews = await OrderService.GetOrdersForAdmin();
        }
    }
}
