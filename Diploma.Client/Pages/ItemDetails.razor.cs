using Diploma.Domain.Entities;
using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Diploma.Client.Pages
{
    public partial class ItemDetails
    {
        [Parameter]
        public int Id { get; set; }
        private ItemDto? itemDto { get; set; } = new ItemDto();
        private bool showSnackbar;


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
            showSnackbar = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (showSnackbar)
            {
                _snackBar.Add("The item was successfully added to the Shopping Cart!", Severity.Success);
                showSnackbar = false;
            }
        }
    }
}