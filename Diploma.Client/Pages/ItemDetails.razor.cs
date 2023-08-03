using Diploma.Domain.Entities;
using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class ItemDetails
    {
        [Parameter]
        public int Id { get; set; }
        private ItemDto? itemDto { get; set; } = new ItemDto();

        protected override async Task OnParametersSetAsync()
        {
            itemDto = await ItemService.GetItem(Id);
        }

        private async Task AddItemToCart()
        {
            var cartItem = new CartItem
            {
                ItemId = itemDto.Id,
            };

            await CartService.AddItemToCart(cartItem);
        }
    }
}