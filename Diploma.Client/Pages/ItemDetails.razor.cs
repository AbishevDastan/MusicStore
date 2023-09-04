using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using Diploma.DTO.Item;
using Diploma.DTO.Wishlist;
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
        bool isInWishlist;

        protected override async Task OnInitializedAsync()
        {
            await LoadWishlist();
            itemDto = await ItemService.GetItem(Id);
            isInWishlist = await WishlistService.IsInWishlist(itemDto.Id);
            BreadcrumbService.ClearBreadcrumbs();
            BreadcrumbService.AddBreadcrumb("Home", "/");
            BreadcrumbService.AddBreadcrumb("Product Details", "#");
        }
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
            itemDto.QuantityInStock -= 1;
            showSnackbar = true;
            NavigationManager.NavigateTo("/cart");
        }

        private async Task ToggleWishlist()
        {
            if (isInWishlist)
            {
                await WishlistService.DeleteItemFromWishlist(itemDto.Id);
            }
            else
            {
                var wishlistItem = new WishlistItem
                {
                    ItemId = itemDto.Id,
                };

                await WishlistService.AddItemToWishlist(wishlistItem);
            }
            isInWishlist = !isInWishlist;
            await LoadWishlist();
        }

        private async Task LoadWishlist()
        {
            await WishlistService.GetNumberOfWishlistItems();
            await WishlistService.GetWishlistItemsLocally();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (showSnackbar)
            {
                SnackBar.Add("The item was successfully added to the Shopping Cart!", Severity.Success);
                showSnackbar = false;
            }
        }
    }
}