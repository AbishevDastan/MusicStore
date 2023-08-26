using Diploma.DTO.Wishlist;

namespace Diploma.Client.Pages
{
    public partial class Wishlist
    {
        List<AddItemToWishlistDto> addedWishlistItems = null;
        string message;

        protected override async Task OnInitializedAsync()
        {
            await LoadWishlist();
            _breadcrumbService.ClearBreadcrumbs();
            _breadcrumbService.AddBreadcrumb("Home", "/");
            _breadcrumbService.AddBreadcrumb("Wishlist", "/wishlist");
        }

        private async Task DeleteItemFromWishlist(int itemId)
        {
            await _wishlistService.DeleteItemFromWishlist(itemId);
            await LoadWishlist();
        }

        private async Task LoadWishlist()
        {
            await _wishlistService.GetNumberOfWishlistItems();
            addedWishlistItems = await _wishlistService.GetWishlistItemsLocally();
            if (addedWishlistItems == null || addedWishlistItems.Count == 0)
            {
                message = "Your wishlist is empty.";
            }
        }
    }
}