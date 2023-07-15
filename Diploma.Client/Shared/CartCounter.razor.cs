using Diploma.DTO;

namespace Diploma.Client.Shared
{
    public partial class CartCounter
    {
        public int? BadgeContent { get; set; }

        private int GetCartItemsCount()
        {
            var cart = SyncLocalStorageService.GetItem<List<CartItemDto>>("cart");
            if (cart != null)
            {
                return cart.Count;
            }
            else
            {
                BadgeContent = null;
                return 0;
            }
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
