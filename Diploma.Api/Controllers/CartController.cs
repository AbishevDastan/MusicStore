using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult<List<AddItemToCartDto>>> GetItemsFromCart([FromBody] List<CartItem> cartItems)
        {
            var result = await _cartRepository.GetItemsFromCart(cartItems);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<AddItemToCartDto>>> PutCartItemsToDatabase(List<CartItem> cartItems)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _cartRepository.PutCartItemsToDatabase(cartItems, userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("cart-items-count")]
        public async Task<ActionResult<int>> GetNumberOfCartItems(int userId)
        { 
            return await _cartRepository.GetNumberOfCartItems(userId);    
        }
    }
}
