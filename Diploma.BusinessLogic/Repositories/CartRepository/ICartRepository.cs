using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<List<AddItemToCartDto>> GetItemsFromCart(List<CartItem> cartItems);
        Task<List<AddItemToCartDto>> PutCartItemsToDatabase(List<CartItem> cartItems, int userId);
        Task<int> GetNumberOfCartItems(int userId);
    }
}
