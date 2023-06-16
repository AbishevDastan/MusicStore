using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItemDTO cartItemDTO);
        Task<List<CartItemDTO>> GetCartItems();
        Task<List<AddItemToCartDTO>> GetItemsFromCart();
        Task DeleteItemFromCart(int itemId);
        Task UpdateItemsQuantity(AddItemToCartDTO item);
    }
}
