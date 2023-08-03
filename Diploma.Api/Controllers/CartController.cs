using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddItemToCartDto>>> GetCartItemsFromDatabase()
        {
            return Ok(await _cartRepository.GetCartItemsFromDatabase());
        }

        [HttpPost]
        public async Task<ActionResult<List<AddItemToCartDto>>> PostCartItemsToDatabase(List<CartItem> cartItems)
        {
            return Ok(await _cartRepository.PostCartItemsToDatabase(cartItems));
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<List<bool>>> UpdateNumberOfCartItems(CartItem cartItem)
        {
            return Ok(await _cartRepository.UpdateNumberOfCartItems(cartItem));
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<List<bool>>> AddCartItemToDatabase(CartItem cartItem)
        {
            return Ok(await _cartRepository.AddCartItemsToDatabase(cartItem));
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<ActionResult<List<AddItemToCartDto>>> RemoveCartItemFromDatabase(int itemId)
        {
            return Ok(await _cartRepository.RemoveCartItemsFromDatabase(itemId));
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult<List<AddItemToCartDto>>> GetCartItemsLocally([FromBody] List<CartItem> cartItems)
        {
            return Ok(await _cartRepository.GetCartItemsLocally(cartItems));
        }

        [HttpGet]
        [Route("cart-items-count")]
        public async Task<int> GetNumberOfCartItems()
        {
            return await _cartRepository.GetNumberOfCartItems();
        }
    }
}
