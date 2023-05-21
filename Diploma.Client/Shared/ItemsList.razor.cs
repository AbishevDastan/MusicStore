using Diploma.BusinessLogic.Services.ItemService;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System.Net.Http.Json;

namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        protected override void OnInitialized()
        {
            ItemService.ItemsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ItemService.ItemsChanged -= StateHasChanged;
        }

        private string GetPriceMessage(ItemDTO item)
        {
            var variants = item.Variants;
            if (variants.Count == 0) 
            {
                return string.Empty;
            }
            else if(variants.Count == 1) 
            {
                return $"{variants[0].Price}";
            }
            decimal minimalPrice = variants.Min(x => x.Price);
            return $"Starting at ${minimalPrice}";
        }   
    }
}
