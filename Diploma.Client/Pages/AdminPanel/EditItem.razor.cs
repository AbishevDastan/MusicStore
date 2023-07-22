using Diploma.DTO;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class EditItem
    {
        [Parameter]
        public int? Id { get; set; }

        string btnText = string.Empty;

        ItemDto itemDto = new() { };

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetAdminCategories();
            btnText = Id == null ? "Save" : "Update Product";
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id is not null)
            {
                var result = await ItemService.GetItem((int)Id);
                if (result != null)
                {
                    itemDto = result;
                }
                else
                {
                    NavigationManager.NavigateTo("/item/admin");
                }
            }
        }

        async Task HandleSubmit()
        {
            if (Id == null)
            {
                await ItemService.CreateItem(itemDto);
            }
            else
            {
                await ItemService.UpdateItem((int)Id, itemDto);
            }
        }

        async Task DeleteItem()
        {
            await ItemService.DeleteItem(itemDto.Id);
        }
    }
}
