using Diploma.Domain.Entities;
using Diploma.DTO.Wishlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.WishlistRepository
{
    public interface IWishlistRepository
    {
        Task<bool> AddWishlistItemsToDatabase(WishlistItem wishllistItem);
        Task<bool> RemoveWishlistItemsFromDatabase(int itemId);
        Task<List<AddItemToWishlistDto>> PostWishlistItemsToDatabase(List<WishlistItem> wishlistItems);
        Task<List<AddItemToWishlistDto>> GetWishlistItemsFromDatabase(int? userId = null);
        Task<List<AddItemToWishlistDto>> GetWishlistItemsLocally(List<WishlistItem> wishlistItems);
        Task<int> GetNumberOfWishlistItems();
    }
}
