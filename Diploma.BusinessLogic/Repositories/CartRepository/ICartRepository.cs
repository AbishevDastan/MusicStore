using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<List<AddItemToCartDto>> GetItemsFromCart(List<CartItemDto> cartItems);
    }
}
