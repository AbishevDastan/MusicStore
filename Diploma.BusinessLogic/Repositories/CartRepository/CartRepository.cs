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

        public async Task<List<AddItemToCartDTO>> GetItemsFromCart(List<CartItemDTO> cartItems)
        {
            var result = new List<AddItemToCartDTO>();

            foreach (var cartItem in cartItems)
            {
                var item = await _dataContext.Items
                    .Where(i => i.Id == cartItem.ItemId)
                    .FirstOrDefaultAsync();

                if(item == null) { continue; }

                var itemVariant = await _dataContext.ItemVariants
                    .Where(v => v.ItemId == cartItem.ItemId
                     && v.ItemTypeId == cartItem.ItemTypeId)
                    .Include(v => v.ItemType)
                    .FirstOrDefaultAsync();

                if(itemVariant == null) { continue;}

                var addedCartItem = new AddItemToCartDTO
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    Quantity = cartItem.Quantity,
                    Price = itemVariant.Price,
                    ItemTypeId = itemVariant.ItemTypeId,
                    ItemType = itemVariant.ItemType.Name
                };

                result.Add(addedCartItem);
            }
            return result;
        }
    }
}
