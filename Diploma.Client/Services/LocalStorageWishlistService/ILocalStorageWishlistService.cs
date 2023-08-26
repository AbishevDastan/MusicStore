namespace Diploma.Client.Services.LocalStorageWishlistService
{
    public interface ILocalStorageWishlistService
    {
        Task<List<int>> GetWishlistItems();
        Task AddToWishlist(int itemId);
        Task RemoveFromWishlist(int itemId);
        Task UpdateWishlist(List<int> wishlist);
    }
}
