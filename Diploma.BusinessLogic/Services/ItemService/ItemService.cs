using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
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

        public event Action ItemsChanged;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public string Message { get; set; } = "Loading items...";

        public async Task GetItems(string? categoryUrl)
        {
            var result = categoryUrl == null ?
                 await _httpClient.GetFromJsonAsync<List<ItemDTO>>("api/item") :
                 await _httpClient.GetFromJsonAsync<List<ItemDTO>>($"api/item/category/{categoryUrl}");

            if (result != null)
            {
                Items = result;
            }

            ItemsChanged?.Invoke();
        }

        public async Task<ItemDTO> GetItem(int itemId)
        {
            var result = await _httpClient.GetFromJsonAsync<ItemDTO>($"api/Item/{itemId}");
            return result;
        }

        public async Task SearchItem(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ItemDTO>>($"api/item/search/{searchText}");
            if (result != null) 
            {
                Items = result;
            }
            if (Items.Count == 0)
            {
                Message = "No products found.";
            }
            ItemsChanged?.Invoke();
        }

        public async Task<List<string>> GetItemSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>($"api/item/searchsuggestions/{searchText}");
            return result;
        }
    }
}
