using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.ItemService
{
    public interface IItemService
    {
        List<ItemDto> Items { get; set; }
        List<ItemDto> AdminItems { get; set; }
        string Message { get; set; }
        event Action ItemsChanged;

        Task GetItems(string? categoryUrl);
        Task<ItemDto> GetItem(int itemId);
        Task SearchItem(string searchText);
        Task<List<string>> GetItemSearchSuggestions(string searchText);

        Task GetAdminItems();
        Task CreateItem(ItemDto itemDto);
        Task UpdateItem(int id, ItemDto itemDto);
        Task DeleteItem(int id);
    }
}
