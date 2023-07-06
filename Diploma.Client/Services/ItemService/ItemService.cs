using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public event Action ItemsChanged;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
        public string Message { get; set; } = "Loading items...";
        //public List<ItemDto> AdminItems { get; set; }

        public async Task GetItems(string? categoryUrl)
        {
            var result = categoryUrl == null ?
                 await _httpClient.GetFromJsonAsync<List<ItemDto>>("api/item/featured") :
                 await _httpClient.GetFromJsonAsync<List<ItemDto>>($"api/item/category/{categoryUrl}");

            if (result != null)
            {
                Items = result;
            }

            ItemsChanged?.Invoke();
        }

        public async Task<ItemDto> GetItem(int itemId)
        {
            var result = await _httpClient.GetFromJsonAsync<ItemDto>($"api/Item/{itemId}");
            return result;
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

        //public async Task GetAdminItems()
        //{
        //    var result = await _httpClient.GetFromJsonAsync<List<ItemDto>>("api/item/admin");
        //    AdminItems = result;
        //    if (Items.Count == 0)
        //    {
        //        Message = "No products found.";
        //    }
        //}

        //public async Task<ItemDto> AddItem(ItemDto itemDto)
        //{
        //    var result = await _httpClient.PostAsJsonAsync("api/item", itemDto);
        //    var createdItem = await result.Content.ReadFromJsonAsync<ItemDto>();

        //    return createdItem;
        //}

        //public async Task<ItemDto> UpdateItem(ItemDto itemDto)
        //{
        //    var result = await _httpClient.PutAsJsonAsync($"api/item", itemDto);
        //    return await result.Content.ReadFromJsonAsync<ItemDto>();
        //}

        //public async Task RemoveItem(ItemDto itemDto)
        //{
        //    var result = await _httpClient.DeleteAsync($"api/item/{itemDto.Id}");
        //}
    }
}
