using Diploma.BusinessLogic.Services.ItemService;
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
        private ItemDTO? Item { get; set; }
        private int currentTypeId = 1;
        private string Message { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Message = "Loading";
            Item = await ItemService.GetItem(Id);

            if (Item.Variants.Count > 0)
            {
                currentTypeId = Item.Variants[0].ItemTypeId;
            }
        }

        private ItemVariantDTO GetSelectedVariant()
        {
            var variant = Item.Variants.FirstOrDefault(x => x.ItemTypeId == currentTypeId);
            return variant;
        }
    }
}