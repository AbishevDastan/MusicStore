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
        event Action ItemsChanged;
        List<ItemDto> Items { get; set; }
        //List<ItemDto> AdminItems { get; set; }
        string Message { get; set; }

        Task GetItems(string? categoryUrl);
        Task<ItemDto> GetItem(int itemId);
        Task SearchItem(string searchText);
        Task<List<string>> GetItemSearchSuggestions(string searchText);

        //Task GetAdminItems();
        //Task<ItemDto> AddItem(ItemDto item);
        //Task<ItemDto> UpdateItem(ItemDto item);
        //Task RemoveItem(ItemDto item);
    }
}
