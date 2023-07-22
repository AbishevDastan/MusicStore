using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepository _userRepository;

        public CartRepository(DataContext dataContext, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _userRepository = userRepository;
        }

        public async Task<bool> AddCartItemsToDatabase(CartItem cartItem)
        {
            var theSameItem = await _dataContext.CartItems
                .FirstOrDefaultAsync(ci => ci.ItemId == cartItem.ItemId && ci.UserId == _userRepository.GetUserId());
            if (theSameItem == null)
            {
                _dataContext.CartItems.Add(cartItem);
            }
            else
            {
                theSameItem.Quantity += cartItem.Quantity;
            }

            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<AddItemToCartDto>> GetCartItemsFromDatabase()
        {
            return await GetCartItemsLocally(await _dataContext.CartItems
                .Where(ci => ci.UserId == _userRepository.GetUserId())
                .ToListAsync());
        }

        public async Task<List<AddItemToCartDto>> GetCartItemsLocally(List<CartItem> cartItems)
        {
            var result = new List<AddItemToCartDto>();

            foreach (var cartItem in cartItems)
            {
                var item = await _dataContext.Items
                    .Where(i => i.Id == cartItem.ItemId)
                    .FirstOrDefaultAsync();

                if (item == null) { continue; }

                var addedCartItem = new AddItemToCartDto
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Quantity = cartItem.Quantity,
                    Price = item.Price,
                };

                result.Add(addedCartItem);
            }
            return result;
        }

        public async Task<int> GetNumberOfCartItems()
        {
            return (await _dataContext.CartItems
                .Where(ci => ci.UserId == _userRepository.GetUserId())
                .ToListAsync()).Count;
        }

        public async Task<List<AddItemToCartDto>> PostCartItemsToDatabase(List<CartItem> cartItems)
        {
            cartItems.ForEach(ci => ci.UserId = _userRepository.GetUserId());

            _dataContext.CartItems.AddRange(cartItems);
            await _dataContext.SaveChangesAsync();

            return await GetCartItemsFromDatabase();
        }

        public async Task<bool> RemoveCartItemsFromDatabase(int itemId)
        {
            var cartItem = await _dataContext.CartItems
                .FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.UserId == _userRepository.GetUserId());

            if (cartItem == null)
            {
                return false;
            }
            _dataContext.CartItems.Remove(cartItem);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateNumberOfCartItems(CartItem cartItem)
        {
            var cartItem1 = await _dataContext.CartItems
                    .FirstOrDefaultAsync(ci => ci.ItemId == cartItem.ItemId && ci.UserId == _userRepository.GetUserId());
            if (cartItem1 == null)
            {
                return false;
            }
            cartItem1.Quantity = cartItem.Quantity;
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
