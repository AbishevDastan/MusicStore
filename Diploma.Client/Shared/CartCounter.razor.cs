namespace Diploma.Client.Shared
{
    public partial class CartCounter
    {
        public int? BadgeContent { get; set; }

        private int GetCartItemsCount()
        {
            var cartItemsCount = SyncLocalStorageService.GetItem<int>("cartItemsCount");
            //if (cartItemsCount != null)
            //{
                BadgeContent = cartItemsCount;
                return cartItemsCount;
            //}
            //else
            //{
            //    BadgeContent = null;
            //    return 0;
            //}
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
