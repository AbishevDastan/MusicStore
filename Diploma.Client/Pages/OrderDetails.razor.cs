using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }
        DTO.Orders.OrderDetails orderDetails = new DTO.Orders.OrderDetails();
        Order order = new Order();
        DeliveryInformation deliveryInfo;

        protected override async Task OnInitializedAsync()
        {
            orderDetails = await OrderService.GetOrderDetails(OrderId);
            order = await OrderService.GetOrder(OrderId);
            deliveryInfo = await DeliveryService.GetDeliveryInfo(order.DeliveryInformationId);
        }

        public async Task CancelOrder()
        {
            await OrderService.CancelOrder(OrderId);
            NavigationManager.NavigateTo("/orders");
        }
    }
}
