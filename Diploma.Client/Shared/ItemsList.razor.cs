using Diploma.Domain;
using Diploma.Domain.Entities;
using System.Net.Http.Json;

namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        private static List<Item> Items = new List<Item>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<ServiceResponse<List<Item>>>("api/Item");
            if (result !=null && result.Data is not null)
            {
                Items = result.Data;
            }
        }
    }
}
