using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<bool> AddCartItemsToDatabase(CartItem cartItem);
        Task<bool> UpdateNumberOfCartItems(CartItem cartItem);
        Task<bool> RemoveCartItemsFromDatabase(int itemId);
        Task<List<AddItemToCartDto>> PostCartItemsToDatabase(List<CartItem> cartItems);
        Task<List<AddItemToCartDto>> GetCartItemsFromDatabase();
        Task<List<AddItemToCartDto>> GetCartItemsLocally(List<CartItem> cartItems);
        Task<int> GetNumberOfCartItems();
    }
}
