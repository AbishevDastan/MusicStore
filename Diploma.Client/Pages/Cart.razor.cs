using Diploma.DTO.Cart;
using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Cart
    {
        List<AddItemToCartDto> addedCartItems = null;
        ItemDto itemDto = new ItemDto();
        string message;
        private bool IsQuantityExceedingStock { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
            foreach (var addedCartItem in addedCartItems)
            {
                itemDto = await ItemService.GetItem(addedCartItem.ItemId);
            }

            BreadcrumbService.ClearBreadcrumbs();
            BreadcrumbService.AddBreadcrumb("Home", "/");
            BreadcrumbService.AddBreadcrumb("Cart", "/cart");
        }

        private async Task DeleteItemFromCart(int itemId)
        {
            await CartService.DeleteItemFromCart(itemId);
            await LoadCart();
        }

        private async Task LoadCart()
        {
            await CartService.GetNumberOfCartItems();
            addedCartItems = await CartService.GetCartItemsLocally();
            if (addedCartItems == null || addedCartItems.Count == 0)
            {
                message = "Your cart is empty.";
            }
        }

        private async Task UpdateItemsQuantity(ChangeEventArgs e, AddItemToCartDto cartItem)
        {
            cartItem.Quantity = int.Parse(e.Value.ToString());
            if (cartItem.Quantity < 1)
                cartItem.Quantity = 1;
            else if (cartItem.Quantity > itemDto.QuantityInStock)
            {
                cartItem.Quantity = itemDto.QuantityInStock;
                IsQuantityExceedingStock = true;
                message = $"The quantity exceeds available stock, only {itemDto.QuantityInStock} items available.";
            }
            else
            {
                IsQuantityExceedingStock = false;
                message = string.Empty;
                await CartService.UpdateItemsQuantity(cartItem);
            }


            //var newQuantity = Convert.ToInt32(e.Value);
            //if (newQuantity > itemDto.QuantityInStock)
            //{

            //}
            //else
            //{
            //    await CartService.UpdateItemsQuantity(cartItem);
            //}
        }

        public void ProceedToCheckout()
        {
            NavigationManager.NavigateTo("/checkout");
        }
    }
}
