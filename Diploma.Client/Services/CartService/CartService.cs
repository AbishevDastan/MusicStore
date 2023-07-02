using Blazored.LocalStorage;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storage;

        public CartService(HttpClient httpClient, ILocalStorageService storage)
        {
            _httpClient = httpClient;
            _storage = storage;
        }
        public event Action OnChange;

        public async Task AddItemToCart(CartItemDto cartItem)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDto>>("cart");
            if (cart == null)
            {
                cart = new List<CartItemDto>();
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
            OnChange.Invoke();
        }

        public async Task DeleteItemFromCart(int itemId)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDto>>("cart");
            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(i => i.ItemId == itemId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _storage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        public async Task<List<CartItemDto>> GetCartItems()
        {
            var cart = await _storage.GetItemAsync<List<CartItemDto>>("cart");
            if (cart == null)
            {
                cart = new List<CartItemDto>();
            }
            return cart;
        }

        public async Task<List<AddItemToCartDto>> GetItemsFromCart()
        {
            var cartItems = await _storage.GetItemAsync<List<CartItemDto>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/items", cartItems);
            var addedCartItems = await response.Content.ReadFromJsonAsync<List<AddItemToCartDto>>();
            return addedCartItems;
        }

        public async Task UpdateItemsQuantity(AddItemToCartDto item)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDto>>("cart");
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
