using Diploma.BusinessLogic.Services.ItemService;
using Diploma.Domain;
using Diploma.Domain.Entities;
using System.Net.Http.Json;

namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        protected override async Task OnInitializedAsync()
        {
            await ItemService.GetItems();
        }
    }
}
