using Diploma.DTO.Item;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Diploma.Client.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public event Action ItemsChanged;

        public ItemService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
        public List<ItemDto> AdminItems { get; set; } = new List<ItemDto>();
        public string Message { get; set; }

        public async Task GetItems(string? categoryUrl)
        {
            var result = categoryUrl == null ?
                 await _httpClient.GetFromJsonAsync<List<ItemDto>>("api/item") :
                 await _httpClient.GetFromJsonAsync<List<ItemDto>>($"api/item/category/{categoryUrl}");

            if (result != null)
            {
                Items = result;
            }

            ItemsChanged?.Invoke();
        }

        public async Task<ItemDto?> GetItem(int itemId)
        {
            var result = await _httpClient.GetAsync($"api/Item/{itemId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<ItemDto>();
            }
            else
            {
                return null;
            }
        }

        public async Task SearchItem(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ItemDto>>($"api/item/search/{searchText}");
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

        //Admin Panel
        public async Task GetAdminItems()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ItemDto>>("api/item/admin");
            AdminItems = result;
            if (Items.Count == 0)
            {
                Message = "No products found.";
            }
        }

        public async Task<List<ItemDetailsForStatistics>> GetStatistics()
        {
            return await _httpClient.GetFromJsonAsync<List<ItemDetailsForStatistics>>("api/item/admin/statistics");
        }

        public async Task CreateItem(ItemDto itemDto)
        {
            await _httpClient.PostAsJsonAsync("api/item/admin", itemDto);
            _navigationManager.NavigateTo("items/admin");
        }

        public async Task UpdateItem(int id, ItemDto itemDto)
        {
            await _httpClient.PutAsJsonAsync($"api/item/admin/{id}", itemDto);
            _navigationManager.NavigateTo("items/admin");
        }

        public async Task DeleteItem(int id)
        {
            await _httpClient.DeleteAsync($"api/item/admin/{id}");
            _navigationManager.NavigateTo("items/admin");
        }
    }
}
