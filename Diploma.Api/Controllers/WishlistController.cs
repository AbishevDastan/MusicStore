using Diploma.BusinessLogic.Repositories.WishlistRepository;
using Diploma.Domain.Entities;
using Diploma.DTO.Wishlist;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistRepository _wishListRepository;

        public WishlistController(IWishlistRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddItemToWishlistDto>>> GetWishlistItemsFromDatabase()
        {
            return Ok(await _wishListRepository.GetWishlistItemsFromDatabase());
        }

        [HttpPost]
        public async Task<ActionResult<List<AddItemToWishlistDto>>> PostWishlistItemsToDatabase(List<WishlistItem> wishlistItems)
        {
            return Ok(await _wishListRepository.PostWishlistItemsToDatabase(wishlistItems));
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<List<bool>>> AddWishlistItemToDatabase(WishlistItem wishlistItem)
        {
            return Ok(await _wishListRepository.AddWishlistItemsToDatabase(wishlistItem));
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<ActionResult<List<AddItemToWishlistDto>>> RemoveWishlistItemFromDatabase(int itemId)
        {
            return Ok(await _wishListRepository.RemoveWishlistItemsFromDatabase(itemId));
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult<List<AddItemToWishlistDto>>> GetWishlistItemsLocally([FromBody] List<WishlistItem> wishlistItems)
        {
            return Ok(await _wishListRepository.GetWishlistItemsLocally(wishlistItems));
        }

        [HttpGet]
        [Route("wishlist-items-count")]
        public async Task<int> GetNumberOfCartItems()
        {
            return await _wishListRepository.GetNumberOfWishlistItems();
        }
    }
}
