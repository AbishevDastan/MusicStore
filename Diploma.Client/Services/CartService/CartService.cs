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
                Console.WriteLine("Authenticated");
            }
            else
            {
                Console.WriteLine("Not authenticated");
            }

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
            await GetNumberOfCartItems();
        }

        public async Task DeleteItemFromCart(int itemId)
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
                await GetNumberOfCartItems();
            }
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            await GetNumberOfCartItems();
            var cart = await _storage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }

        public async Task<List<AddItemToCartDto>> GetItemsFromCart()
        {
            var cartItems = await _storage.GetItemAsync<List<CartItem>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/items", cartItems);
            var addedCartItems = await response.Content.ReadFromJsonAsync<List<AddItemToCartDto>>();
            return addedCartItems;
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
                await _storage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }
            OnChange.Invoke();
        }

        public async Task PutCartItemsToDatabase(bool clearCartLocally = false)
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
