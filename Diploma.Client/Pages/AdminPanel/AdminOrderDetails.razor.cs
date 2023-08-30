using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }
        DTO.Orders.OrderDetails orderDetails = new DTO.Orders.OrderDetails();
        Order order = new Order();
        DeliveryInformation deliveryInfo;

        protected override async Task OnInitializedAsync()
        {
            orderDetails = await OrderService.GetOrderDetailsForAdmin(OrderId);
            order = await OrderService.GetOrder(OrderId);
            deliveryInfo = await DeliveryService.GetDeliveryInfoForAdmin(order.DeliveryInformationId);
        }
    }
}
