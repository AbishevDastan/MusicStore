using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }
        DTO.Orders.OrderDetails order = new DTO.Orders.OrderDetails();

        protected override async Task OnInitializedAsync()
        {
            order = await _orderService.GetOrderDetails(OrderId);
        }

        public async Task CancelOrder()
        {
            await _orderService.CancelOrder(OrderId);
            _navigationManager.NavigateTo("/orders");
        }
    }
}
