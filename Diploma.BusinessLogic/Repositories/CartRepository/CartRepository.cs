using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Diploma.BusinessLogic.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;

        public CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AddItemToCartDto>> GetItemsFromCart(List<CartItemDto> cartItems)
        {
            var result = new List<AddItemToCartDto>();

            foreach (var cartItem in cartItems)
            {
                var item = await _dataContext.Items
                    .Where(i => i.Id == cartItem.ItemId)
                    .FirstOrDefaultAsync();

                if(item == null) { continue; }

                var addedCartItem = new AddItemToCartDto
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    Quantity = cartItem.Quantity,
                    Price = item.Price,
                };

                result.Add(addedCartItem);
            }
            return result;
        }
    }
}
