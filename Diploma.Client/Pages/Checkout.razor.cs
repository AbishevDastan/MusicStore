﻿using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Checkout
    {
        List<DeliveryInformation> deliveryInfos = null;
        int selectedDeliveryInfoId;
        List<AddItemToCartDto> addedCartItems = null;
        private bool IsDeliveryInfoSelected { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            deliveryInfos = await DeliveryService.GetDeliveryInfos();
            await LoadCart();
            BreadcrumbService.ClearBreadcrumbs();
            BreadcrumbService.AddBreadcrumb("Home", "/");
            BreadcrumbService.AddBreadcrumb("Cart", "/cart");
            BreadcrumbService.AddBreadcrumb("Checkout", "/checkout");
        }

        private async Task LoadCart()
        {
            await CartService.GetNumberOfCartItems();
            addedCartItems = await CartService.GetCartItemsLocally();
        }

        private async Task PlaceOrder()
        {
            //foreach (var info in deliveryInfos)
            //{
            //    await DeliveryService.LinkDeliveryInfoToOrder(selectedDeliveryInfoId, info.OrderId);
            //}
            await OrderService.PlaceOrder(selectedDeliveryInfoId);
            NavigationManager.NavigateTo("/orders");
        }

        private void ManageDeliveryInfo()
        {
            NavigationManager.NavigateTo("/profile");
        }

        private void AddDeliveryInfo()
        {
            NavigationManager.NavigateTo("/delivery");
        }

        private void SetSelectedDeliveryInfo(int deliveryInfoId)
        {
            selectedDeliveryInfoId = deliveryInfoId;
            IsDeliveryInfoSelected = true;
        }
    }
}
