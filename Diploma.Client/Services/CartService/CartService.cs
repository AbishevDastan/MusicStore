using Blazored.LocalStorage;
using Diploma.Client.Services.AuthenticationService;
using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using System.Net.Http.Json;

namespace Diploma.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storage;
        private readonly IAuthenticationService _authenticationService;

        public CartService(HttpClient httpClient, ILocalStorageService storage, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _storage = storage;
            _authenticationService = authenticationService;
        }
        public event Action OnChange;

        public async Task AddItemToCart(CartItem cartItem)
        {
            if (await _authenticationService.IsAuthenticated())
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

                var existingItem = cart.Find(i => i.ItemId == cartItem.ItemId);

                if (existingItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    existingItem.Quantity += cartItem.Quantity;
                }

                await _storage.SetItemAsync("cart", cart);
            }
            await GetNumberOfCartItems();
        }

        public async Task DeleteItemFromCart(int itemId)
        {
            if (await _authenticationService.IsAuthenticated())
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
            if (await _authenticationService.IsAuthenticated())
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
            if (await _authenticationService.IsAuthenticated())
            {
                var cartItemsCount = await _httpClient.GetFromJsonAsync<int>("api/cart/cart-items-count");
                await _storage.SetItemAsync<int>("cartItemsCount", cartItemsCount);
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                await _storage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
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

            await _httpClient.PostAsJsonAsync("api/cart", cart);

            if (clearCartLocally)
            {
                await _storage.RemoveItemAsync("cart");
            }
        }

        public async Task UpdateItemsQuantity(AddItemToCartDto addcartItemDto)
        {
            if (await _authenticationService.IsAuthenticated())
            {
                var cartItem = new CartItem
                {
                    ItemId = addcartItemDto.ItemId,
                    Quantity = addcartItemDto.Quantity
                };
                await _httpClient.PutAsJsonAsync("api/cart/update", cartItem);
            }
            else
            {
                var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }
                var cartItem = cart.Find(i => i.ItemId == addcartItemDto.ItemId);
                if (cartItem != null)
                {
                    cartItem.Quantity = addcartItemDto.Quantity;
                    await _storage.SetItemAsync("cart", cart);
                }
            }
        }
    }
}
