using Diploma.Client.Services.OrderService;
using Diploma.DTO.Order;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrders
    {
        private int orderCount;
        private List<OrderOverview> orders;

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
