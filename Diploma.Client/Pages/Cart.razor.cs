using Diploma.BusinessLogic.Services.CartService;
using Diploma.DTO;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class Cart
    {
        List<AddItemToCartDTO> addedCartItems = null;
        string message = "Loading Shopping Cart page...";

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
        }

        private async Task DeleteItemFromCart(int itemId, int itemTypeId)
        {
            await CartService.DeleteItemFromCart(itemId, itemTypeId);
            await LoadCart();
        }

        private async Task LoadCart()
        {
            if ((await CartService.GetCartItems()).Count == 0)
            {
                message = "Your cart is empty.";
                addedCartItems = new List<AddItemToCartDTO>();
            }
            else
            {
                addedCartItems = await CartService.GetItemsFromCart();
            }
        }

        private async Task UpdateItemsQuantity(ChangeEventArgs ev, AddItemToCartDTO item)
        {
            item.Quantity = int.Parse(ev.Value.ToString());
            if (item.Quantity < 1)
                item.Quantity = 1;
            await CartService.UpdateItemsQuantity(item);
            
        }
    }
}
