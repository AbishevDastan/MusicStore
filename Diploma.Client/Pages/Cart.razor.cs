using Diploma.DTO;
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

        private async Task UpdateItemsQuantity(ChangeEventArgs ev, AddItemToCartDto item)
        {
            item.Quantity = int.Parse(ev.Value.ToString());
            if (item.Quantity < 1)
                item.Quantity = 1;

            await CartService.UpdateItemsQuantity(item);

        }
    }
}
