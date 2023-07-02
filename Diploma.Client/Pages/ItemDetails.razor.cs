using Diploma.Client.Services.CartService;
using Diploma.Client.Services.ItemService;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace Diploma.Client.Pages
{
    public partial class ItemDetails
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IItemService ItemService { get; set; }
        [Inject]
        public ICartService CartService { get; set; }
        private ItemDto? Item { get; set; }
        private string Message { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Message = "Loading";
            Item = await ItemService.GetItem(Id);
        }

        private async Task AddItemToCart()
        {
            var cartItem = new CartItemDto
            {
                ItemId = Item.Id,
            };

            await CartService.AddItemToCart(cartItem);
        }
    }
}