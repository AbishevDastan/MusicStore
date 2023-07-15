using AutoMapper;
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
        private readonly IMapper _mapper;

        public CartRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<AddItemToCartDto>> GetItemsFromCart(List<CartItem> cartItems)
        {
            var result = new List<AddItemToCartDto>();

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

                result.Add(addedCartItem);
            }
            return result;
        }

        public async Task<List<AddItemToCartDto>> PutCartItemsToDatabase(List<CartItem> cartItems, int userId)
        {
            cartItems.ForEach(ci => ci.UserId = userId);
            var cartItemsDto = _mapper.Map<CartItem>(cartItems);

            _dataContext.CartItems.AddRange(cartItemsDto);
            await _dataContext.SaveChangesAsync();

            return await GetItemsFromCart(await _dataContext.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync());
        }
    }
}
