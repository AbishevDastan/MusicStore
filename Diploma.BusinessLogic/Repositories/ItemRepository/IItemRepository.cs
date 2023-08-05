using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO.Item;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.ItemRepository
{
    public interface IItemRepository
    {
        Task<List<ItemDto>> GetItems();
        Task<ItemDto?> GetItem(int itemId);
        Task<List<ItemDto>> GetItemsByCategory(string categoryUrl);
        Task<List<ItemDto>> SearchItem(string searchText);
        Task<List<string>> GetItemSearchSuggestions(string searchText);

        //Admin Panel
        Task<List<ItemDto>> GetAdminItems();
        Task<List<ItemDetailsForStatistics>> GetStatistics();
        Task<ItemDto> CreateItem(ItemDto itemDto);
        Task<ItemDto?> UpdateItem(int itemId, ItemDto itemDto);
        Task<bool> DeleteItem(int itemId);
    }
}
