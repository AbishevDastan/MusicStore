namespace Diploma.Client.Shared
{
    public partial class WishlistCounter
    {
        public int? BadgeContent { get; set; }

        public int GetWishlistItemsCount()
        {
            var wishlistItemsCount = SyncLocalStorageService.GetItem<int>("wishlistItemsCount");
            BadgeContent = wishlistItemsCount;
            return wishlistItemsCount;
        }

        protected override void OnInitialized()
        {
            _wishlistService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            _wishlistService.OnChange -= StateHasChanged;
        }
    }
}
