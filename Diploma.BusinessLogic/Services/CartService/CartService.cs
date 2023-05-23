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

namespace Diploma.BusinessLogic.Services.CartService
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

        public async Task AddItemToCart(CartItemDTO cartItem)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDTO>>("cart");
            if (cart == null) 
            {
                cart = new List<CartItemDTO>();
            }

            var theSameItem = cart.Find(i => i.ItemId == cartItem.ItemId
            && i.ItemTypeId == cartItem.ItemTypeId);

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

        public async Task DeleteItemFromCart(int itemId, int itemTypeId)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDTO>>("cart");
            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(i => i.ItemId == itemId
                && i.ItemTypeId == itemTypeId);
            if (cartItem != null) 
            {
                cart.Remove(cartItem);
                await _storage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        public async Task<List<CartItemDTO>> GetCartItems()
        {
            var cart = await _storage.GetItemAsync<List<CartItemDTO>>("cart");
            if (cart == null) 
            {
                cart = new List<CartItemDTO>();
            }
            return cart;
        }

        public async Task<List<AddItemToCartDTO>> GetItemsFromCart()
        {
            var cartItems = await _storage.GetItemAsync<List<CartItemDTO>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/items", cartItems);
            var addedCartItems = await response.Content.ReadFromJsonAsync<List<AddItemToCartDTO>>();
            return addedCartItems;
        }

        public async Task UpdateItemsQuantity(AddItemToCartDTO item)
        {
            var cart = await _storage.GetItemAsync<List<CartItemDTO>>("cart");
            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(i => i.ItemId == item.ItemId
                && i.ItemTypeId == item.ItemTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = item.Quantity;
                await _storage.SetItemAsync("cart", cart);
            }
        }
    }
}
