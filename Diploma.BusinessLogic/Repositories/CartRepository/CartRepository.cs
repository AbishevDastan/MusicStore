using AutoMapper;
using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CartRepository(DataContext dataContext, IMapper mapper, IUserContext userContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<bool> AddCartItemsToDatabase(CartItem cartItem)
        {
            cartItem.UserId = _userContext.GetUserId();
            var existingItem = await _dataContext.CartItems
                .FirstOrDefaultAsync(ci => ci.ItemId == cartItem.ItemId && ci.UserId == cartItem.UserId);

            if (existingItem == null)
            {
                _dataContext.CartItems.Add(cartItem);
            }
            else
            {
                existingItem.Quantity += cartItem.Quantity;
            }

            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<AddItemToCartDto>> GetCartItemsFromDatabase(int? userId = null)
        {
            if(userId == null)
            userId = _userContext.GetUserId();

            return await GetCartItemsLocally(await _dataContext.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync());
        }

        public async Task<List<AddItemToCartDto>> GetCartItemsLocally(List<CartItem> cartItems)
        {
            var addedCartItems = new List<AddItemToCartDto>();

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

                addedCartItems.Add(addedCartItem);
            }
            return addedCartItems;
        }

        public async Task<int> GetNumberOfCartItems()
        {
            return (await _dataContext.CartItems
                .Where(ci => ci.UserId == _userContext.GetUserId())
                .ToListAsync()).Count;
        }

        public async Task<List<AddItemToCartDto>> PostCartItemsToDatabase(List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                cartItem.UserId = _userContext.GetUserId();
            }

            _dataContext.CartItems.AddRange(cartItems);
            await _dataContext.SaveChangesAsync();

            return await GetCartItemsFromDatabase();
        }

        public async Task<bool> RemoveCartItemsFromDatabase(int itemId)
        {
            var cartItem = await _dataContext.CartItems
                .FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.UserId == _userContext.GetUserId());

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
                    .FirstOrDefaultAsync(ci => ci.ItemId == cartItem.ItemId && ci.UserId == _userContext.GetUserId());
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
