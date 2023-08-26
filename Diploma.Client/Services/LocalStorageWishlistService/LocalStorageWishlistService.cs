using Microsoft.JSInterop;
using System.Text.Json;

namespace Diploma.Client.Services.LocalStorageWishlistService
{
    public class LocalStorageWishlistService : ILocalStorageWishlistService
    {
        private const string WishlistStorageKey = "wishlist";
        private readonly IJSRuntime jsRuntime;

        public LocalStorageWishlistService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<List<int>> GetWishlistItems()
        {
            var wishlistJson = await jsRuntime.InvokeAsync<string>("localStorage.getItem", WishlistStorageKey);
            return string.IsNullOrEmpty(wishlistJson) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(wishlistJson);
        }

        public async Task AddToWishlist(int itemId)
        {
            var wishlist = await GetWishlistItems();
            wishlist.Add(itemId);
            await UpdateWishlist(wishlist);
        }

        public async Task RemoveFromWishlist(int itemId)
        {
            var wishlist = await GetWishlistItems();
            wishlist.Remove(itemId);
            await UpdateWishlist(wishlist);
        }

        public async Task UpdateWishlist(List<int> wishlist)
        {
            var wishlistJson = JsonSerializer.Serialize(wishlist);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", WishlistStorageKey, wishlistJson);
        }
    }
}
