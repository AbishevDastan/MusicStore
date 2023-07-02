using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult<List<AddItemToCartDto>>> GetItemsFromCart([FromBody]List<CartItemDto> cartItems)
        {
            var result = await _cartRepository.GetItemsFromCart(cartItems);
            return Ok(result);
        }
    }
}
