using Blazored.LocalStorage;
using Diploma.Client.Pages;
using Diploma.Client.Services.AuthenticationService;
using Diploma.Domain.Entities;
using Diploma.DTO.Wishlist;
using System.Net.Http.Json;

namespace Diploma.Client.Services.WishlistService
{
    public class WishlistService : IWishlistService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storage;
        private readonly IAuthenticationService _authenticationService;

        public WishlistService(HttpClient httpClient, ILocalStorageService storage, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _storage = storage;
            _authenticationService = authenticationService;
        }

        public event Action OnChange;

        public async Task<bool> IsInWishlist(int itemId)
        {
            var wishlist = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
            //if (wishlist == null)
            //{
            //    return false;
            //}
            //else
            //{
                var wishlistItem = wishlist.Find(i => i.ItemId == itemId);
                if (wishlistItem == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            //}
        }

        public async Task AddItemToWishlist(WishlistItem wishlistItem)
        {
            if (await _authenticationService.IsAuthenticated())
            {
                await _httpClient.PostAsJsonAsync("api/wishlist/add", wishlistItem);
            }
            else
            {
                var wishlist = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
                if (wishlist == null)
                {
                    wishlist = new List<WishlistItem>();
                }

                var theSameItem = wishlist.Find(i => i.ItemId == wishlistItem.ItemId);

                if (theSameItem == null)
                {
                    wishlist.Add(wishlistItem);
                }

                await _storage.SetItemAsync("wishlist", wishlist);
            }
            await GetNumberOfWishlistItems();
        }

        public async Task DeleteItemFromWishlist(int itemId)
        {
            if (await _authenticationService.IsAuthenticated())
            {
                await _httpClient.DeleteAsync($"api/wishlist/{itemId}");
            }
            else
            {
                var wishlist = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
                if (wishlist == null)
                {
                    return;
                }
                var wishlistItem = wishlist.Find(i => i.ItemId == itemId);
                if (wishlistItem != null)
                {
                    wishlist.Remove(wishlistItem);
                    await _storage.SetItemAsync("wishlist", wishlist);
                }
            }
            await GetNumberOfWishlistItems();
        }

        public async Task<List<AddItemToWishlistDto>> GetWishlistItemsLocally()
        {
            if (await _authenticationService.IsAuthenticated())
            {
                return await _httpClient.GetFromJsonAsync<List<AddItemToWishlistDto>>("api/wishlist");
            }
            else
            {
                var wishlistItems = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
                if (wishlistItems == null)
                {
                    return new List<AddItemToWishlistDto>();
                }
                var response = await _httpClient.PostAsJsonAsync("api/wishlist/items", wishlistItems);
                return await response.Content.ReadFromJsonAsync<List<AddItemToWishlistDto>>();
            }
        }

        public async Task GetNumberOfWishlistItems()
        {
            if (await _authenticationService.IsAuthenticated())
            {
                var wishlistItemsCount = await _httpClient.GetFromJsonAsync<int>("api/wishlist/wishlist-items-count");
                await _storage.SetItemAsync<int>("wishlistItemsCount", wishlistItemsCount);
            }
            else
            {
                var wishlist = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
                await _storage.SetItemAsync<int>("wishlistItemsCount", wishlist == null ? 0 : wishlist.Count);
            }
            OnChange.Invoke();
        }

        public async Task PostWishlistItemsToDatabase(bool clearWishlistLocally = false)
        {
            var wishlist = await _storage.GetItemAsync<List<WishlistItem>>("wishlist");
            if (wishlist == null)
            {
                return;
            }
            else
            {
                await _httpClient.PostAsJsonAsync("api/wishlist", wishlist);
            }

            if (clearWishlistLocally)
            {
                await _storage.RemoveItemAsync("wishlist");
            }
        }
    }
}
