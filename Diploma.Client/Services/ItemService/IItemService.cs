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
        Task GetItems(string? categoryUrl);
        Task<ItemDto> GetItem(int itemId);
        string Message { get; set; }
        Task SearchItem(string searchText);
        Task<List<string>> GetItemSearchSuggestions(string searchText);
    }
}
