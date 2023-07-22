using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItem cartItemDTO);
        Task<List<AddItemToCartDto>> GetCartItemsLocally();
        Task DeleteItemFromCart(int itemId);
        Task UpdateItemsQuantity(AddItemToCartDto item);
        Task PostCartItemsToDatabase(bool clearCartLocally);
        Task GetNumberOfCartItems();
    }
}
