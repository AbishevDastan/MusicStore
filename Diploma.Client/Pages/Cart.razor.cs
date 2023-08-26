﻿using Diploma.DTO.Cart;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Cart
    {
        List<AddItemToCartDto> addedCartItems = null;
        string message;

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Cart", "/cart");
        }

        private async Task DeleteItemFromCart(int itemId)
        {
            await _cartService.DeleteItemFromCart(itemId);
            await LoadCart();
        }

        private async Task LoadCart()
        {
            await _cartService.GetNumberOfCartItems();
            addedCartItems = await _cartService.GetCartItemsLocally();
            if (addedCartItems == null || addedCartItems.Count == 0)
            {
                message = "Your cart is empty.";
            }
        }

        private async Task UpdateItemsQuantity(ChangeEventArgs ev, AddItemToCartDto item)
        {
            item.Quantity = int.Parse(ev.Value.ToString());
            if (item.Quantity < 1)
                item.Quantity = 1;

            await _cartService.UpdateItemsQuantity(item);

        }

        public void ProceedToCheckout()
        {
            _navigationManager.NavigateTo("/checkout");
        }
    }
}
