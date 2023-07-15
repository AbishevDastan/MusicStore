using Diploma.DTO;
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
            itemDto = await itemService.GetItem(Id);
        }

        private async Task AddItemToCart()
        {
            var cartItem = new CartItemDto
            {
                ItemId = itemDto.Id,
            };

            await cartService.AddItemToCart(cartItem);
        }
    }
}