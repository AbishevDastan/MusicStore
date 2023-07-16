using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItem cartItemDTO);
        Task<List<CartItem>> GetCartItems();
        Task<List<AddItemToCartDto>> GetItemsFromCart();
        Task DeleteItemFromCart(int itemId);
        Task UpdateItemsQuantity(AddItemToCartDto item);
        Task PutCartItemsToDatabase(bool clearCartLocally);
        Task GetNumberOfCartItems();
    }
}
