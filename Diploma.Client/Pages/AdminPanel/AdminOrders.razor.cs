using Diploma.DTO.Order;
using System.Net.Http;
using System.Net.Http.Json;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrders
    {
        private List<OrderOverview> orders;

        protected override async Task OnInitializedAsync()
        {
            orders = await _orderService.GetOrdersForAdmin();
        }

        public async Task ApproveOrder(int orderId)
        {
            await _orderService.ApproveOrder(orderId);
        }
    }
}
