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
    }
}
