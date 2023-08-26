using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO.Wishlist;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.WishlistRepository
{
    internal class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserContext _userContext;

        public WishlistRepository(DataContext dataContext, IUserContext userContext)
        {
            _dataContext = dataContext;
            _userContext = userContext;
        }

        public async Task<bool> AddWishlistItemsToDatabase(WishlistItem wishlistItem)
        {
            wishlistItem.UserId = _userContext.GetUserId();
            var theSameItem = await _dataContext.WishlistItems
                .FirstOrDefaultAsync(x => x.ItemId == wishlistItem.ItemId && x.UserId == wishlistItem.UserId);
            if (theSameItem == null)
            {
                _dataContext.WishlistItems.Add(wishlistItem);
            }
            else
            {
                throw new ApplicationException("This item is already in wishlist.");
            }

            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<AddItemToWishlistDto>> GetWishlistItemsFromDatabase(int? userId = null)
        {
            if (userId == null)
                userId = _userContext.GetUserId();

            return await GetWishlistItemsLocally(await _dataContext.WishlistItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync());
        }

        public async Task<List<AddItemToWishlistDto>> GetWishlistItemsLocally(List<WishlistItem> wishlistItems)
        {
            var result = new List<AddItemToWishlistDto>();

            foreach (var wishlistItem in wishlistItems)
            {
                var item = await _dataContext.Items
                    .Where(i => i.Id == wishlistItem.ItemId)
                    .FirstOrDefaultAsync();

                if (item == null) { continue; }

                var addedWishlistItem = new AddItemToWishlistDto
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                };

                result.Add(addedWishlistItem);
            }
            return result;
        }

        public async Task<int> GetNumberOfWishlistItems()
        {
            return (await _dataContext.WishlistItems
                .Where(x => x.UserId == _userContext.GetUserId())
                .ToListAsync()).Count;
        }

        public async Task<List<AddItemToWishlistDto>> PostWishlistItemsToDatabase(List<WishlistItem> wishlistItems)
        {
            foreach (var wishlistItem in wishlistItems)
            {
                wishlistItem.UserId = _userContext.GetUserId();
            }
            _dataContext.WishlistItems.AddRange(wishlistItems);
            await _dataContext.SaveChangesAsync();

            return await GetWishlistItemsFromDatabase();
        }

        public async Task<bool> RemoveWishlistItemsFromDatabase(int itemId)
        {
            var wishlistItem = await _dataContext.WishlistItems
                .FirstOrDefaultAsync(x => x.ItemId == itemId && x.UserId == _userContext.GetUserId());

            if (wishlistItem == null)
            {
                return false;
            }
            _dataContext.WishlistItems.Remove(wishlistItem);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
