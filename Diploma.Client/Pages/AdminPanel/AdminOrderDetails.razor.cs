﻿using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class AdminOrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }

        DTO.Order.OrderDetails order = null;

        protected override async Task OnInitializedAsync()
        {
            order = await _orderService.GetOrderDetailsForAdmin(OrderId);
        }
    }
}
