//using Diploma.Client.Services.ItemService;
//using Diploma.Domain.Entities;
//using Diploma.DTO;
//using Microsoft.AspNetCore.Components;

//namespace Diploma.Client.Pages.AdminPanel
//{
//    public partial class EditItem
//    {
//        [Parameter]
//        public int Id { get; set; }

//        ItemDto item = new ItemDto();
//        bool loading = true;
//        string btnText = "";
//        string msg = "Loading...";

//        protected override async Task OnInitializedAsync()
//        {
//            await CategoryService.GetAdminCategories();
//        }

//        protected override async Task OnParametersSetAsync()
//        {
//            if (Id == 0)
//            {
//                item = new ItemDto { IsNew = true };
//                btnText = "Create Product";
//            }
//            else
//            {
//                ItemDto dbItem = await ItemService.GetItem(Id);
//                if (dbItem == null)
//                {
//                    msg = $"Product with Id '{Id}' does not exist!";
//                    return;
//                }
//                item = dbItem;
//                item.IsBeingEdited = true;
//                btnText = "Update Product";
//            }
//            loading = false;
//        }

//        async void AddOrUpdateItem()
//        {
//            if (item.IsNew)
//            {
//                var result = await ItemService.AddItem(item);
//                NavigationManager.NavigateTo($"admin/item/{result.Id}");
//            }
//            else
//            {
//                item.IsNew = false;
//                item = await ItemService.UpdateItem(item);
//                NavigationManager.NavigateTo($"admin/item/{item.Id}", true);
//            }
//        }

        //async void RemoveItem()
        //{
        //    bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
        //        $"Do you really want to delete '{item.Name}'?");
        //    if (confirmed)
        //    {
        //        await ItemService.RemoveItem(item);
        //        NavigationManager.NavigateTo("admin/items");
        //    }
        //}
//    }
//}
