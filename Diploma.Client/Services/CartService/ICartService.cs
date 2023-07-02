using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItemDto cartItemDTO);
        Task<List<CartItemDto>> GetCartItems();
        Task<List<AddItemToCartDto>> GetItemsFromCart();
        Task DeleteItemFromCart(int itemId);
        Task UpdateItemsQuantity(AddItemToCartDto item);
    }
}
