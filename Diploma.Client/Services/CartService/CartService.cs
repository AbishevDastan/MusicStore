using Blazored.LocalStorage;
using Diploma.Client.Services.UserService;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System.Net.Http.Json;

namespace Diploma.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storage;
        private readonly IUserService _userService;

        public CartService(HttpClient httpClient, ILocalStorageService storage, IUserService userService)
        {
            _httpClient = httpClient;
            _storage = storage;
            _userService = userService;
        }
        public event Action OnChange;

        public async Task AddItemToCart(CartItem cartItem)
        {
            if (await _userService.IsAuthenticated())
            {
                await _httpClient.PostAsJsonAsync("api/cart/add", cartItem);
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var theSameItem = cart.Find(i => i.ItemId == cartItem.ItemId);

                if (theSameItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    theSameItem.Quantity += cartItem.Quantity;
                }

                await _storage.SetItemAsync("cart", cart);
            }
            await GetNumberOfCartItems();
        }

        public async Task DeleteItemFromCart(int itemId)
        {
            if (await _userService.IsAuthenticated())
            {
                await _httpClient.DeleteAsync($"api/cart/{itemId}");
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }
                var cartItem = cart.Find(i => i.ItemId == itemId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _storage.SetItemAsync("cart", cart);
                }
            }
        }

        public async Task<List<AddItemToCartDto>> GetCartItemsLocally()
        {
            if (await _userService.IsAuthenticated())
            {
                return await _httpClient.GetFromJsonAsync<List<AddItemToCartDto>>("api/cart");
            }
            else
            {
                var cartItems = await _storage.GetItemAsync<List<CartItem>>("cart");
                if (cartItems == null)
                {
                    return new List<AddItemToCartDto>();
                }
                var response = await _httpClient.PostAsJsonAsync("api/cart/items", cartItems);
                return await response.Content.ReadFromJsonAsync<List<AddItemToCartDto>>();
            }
        }

        public async Task GetNumberOfCartItems()
        {
            if (await _userService.IsAuthenticated())
            {
                var cartItemsCount = await _httpClient.GetFromJsonAsync<int>("api/cart/cart-items-count");
                await _storage.SetItemAsync<int>("cartItemsCount", cartItemsCount);
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                await _storage.SetItemAsync<int>("cartItemsCount", cart == null ? 0 : cart.Count);
            }
            OnChange.Invoke();
        }

        public async Task PostCartItemsToDatabase(bool clearCartLocally = false)
        {
            var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }
            else
            {
                await _httpClient.PostAsJsonAsync("api/cart", cart);
            }

            if (clearCartLocally)
            {
                await _storage.RemoveItemAsync("cart");
            }

        }

        public async Task UpdateItemsQuantity(AddItemToCartDto item)
        {
            if (await _userService.IsAuthenticated())
            {
                var request = new CartItem
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity
                };
                await _httpClient.PutAsJsonAsync("api/cart/update", request);
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }
                var cartItem = cart.Find(i => i.ItemId == item.ItemId);
                if (cartItem != null)
                {
                    cartItem.Quantity = item.Quantity;
                    await _storage.SetItemAsync("cart", cart);
                }
            }
        }
    }
}
