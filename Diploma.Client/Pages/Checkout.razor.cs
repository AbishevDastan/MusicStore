using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using MudBlazor;

namespace Diploma.Client.Pages
{
    public partial class Checkout
    {
        DeliveryInformation deliveryInfo = new DeliveryInformation();
        string selectedDeliveryMethod = "PayOnDelivery";
        List<AddItemToCartDto> addedCartItems = null;

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Cart", "/cart");
            _breadcrumbService.AddBreadcrumb("Checkout", "/checkout");
        }

        private async Task LoadCart()
        {
            await _cartService.GetNumberOfCartItems();
            addedCartItems = await _cartService.GetCartItemsLocally();
            //if (addedCartItems == null || addedCartItems.Count == 0)
            //{
            //    message = "Your cart is empty.";
            //}
        }

        private async Task PlaceOrder()
        {
            await _orderService.PlaceOrder();
            _navigationManager.NavigateTo("/orders");
        }
    }
}
