using Diploma.Domain;
using Diploma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Item> Items { get; set; } = new List<Item>();

        public async Task GetItems()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Item>>>("api/Item");
            if (result != null && result.Data != null)
            {
                Items = result.Data;
            }
        }
    }
}
