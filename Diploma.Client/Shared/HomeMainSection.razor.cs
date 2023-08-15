using Diploma.Domain.Entities;
using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Diploma.Client.Shared
{
    public partial class HomeMainSection
    {
        //[Parameter]
        //public int Id { get; set; }
        //private ItemDto? itemDto { get; set; } = new ItemDto();
        //private bool showSnackbar;

        protected override async Task OnInitializedAsync()
        {
            await _categoryService.GetCategories();
            await _itemService.GetItems(null);
        }

        //private async Task AddItemToWishlist()
        //{
        //    var wishlistItem = new WishlistItem
        //    {
        //        ItemId = itemDto.Id,
        //    };

        //    await _wishlistService.AddItemToWishlist(wishlistItem);
        //    showSnackbar = true;
        //}

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await base.OnAfterRenderAsync(firstRender);

        //    if (showSnackbar)
        //    {
        //        _snackBar.Add("The item was successfully added to the Wishlist!", Severity.Success);
        //        showSnackbar = false;
        //    }
        //}
    }
}
