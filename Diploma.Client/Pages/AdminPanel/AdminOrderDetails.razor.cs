using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }

        DTO.Orders.OrderDetails order = null;

        protected override async Task OnInitializedAsync()
        {
            order = await OrderService.GetOrderDetailsForAdmin(OrderId);
        }
    }
}
