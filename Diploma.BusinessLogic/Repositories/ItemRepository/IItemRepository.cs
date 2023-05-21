using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
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
        Task<List<Item>> GetItems(); 
        Task<Item> GetItem(int itemId);
        Task<List<Item>> GetItemsByCategory(string categoryUrl);
        Task<List<Item>> SearchItem(string searchText);
        Task<List<string>> GetItemSearchSuggestions(string searchText);
    }
}
