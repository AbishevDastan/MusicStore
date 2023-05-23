using Blazored.LocalStorage;
using Diploma.BusinessLogic.Services.CartService;
using Diploma.DTO;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Shared
{
    public partial class CartCounter
    {
        private int GetCartItemsCount()
        {
            var cart = SyncLocalStorageService.GetItem<List<CartItemDTO>>("cart");
            return cart != null ? cart.Count : 0;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
    }
}
