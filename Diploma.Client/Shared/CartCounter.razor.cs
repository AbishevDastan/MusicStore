namespace Diploma.Client.Shared
{
    public partial class CartCounter
    {
        public int? BadgeContent { get; set; }

        public int GetCartItemsCount()
        {
            var cartItemsCount = SyncLocalStorageService.GetItem<int>("cartItemsCount");
            BadgeContent = cartItemsCount;
            return cartItemsCount;
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
