using Diploma.Domain.Entities;
using Diploma.DTO.Wishlist;

namespace Diploma.Client.Services.WishlistService
{
    public interface IWishlistService
    {
        event Action OnChange;
        Task<bool> IsInWishlist(int itemId);
        Task AddItemToWishlist(WishlistItem wishlistItem);
        Task<List<AddItemToWishlistDto>> GetWishlistItemsLocally();
        Task DeleteItemFromWishlist(int itemId);
        Task PostWishlistItemsToDatabase(bool clearWishlistLocally);
        Task GetNumberOfWishlistItems();
    }
}
